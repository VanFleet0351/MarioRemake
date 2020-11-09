using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using System.Collections.Generic;
using SprintZero.FlagPoles;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Items;
using SprintZero.Fireball;
using SprintZero.Decorator;
using SprintZero.Levelmanager;
using SprintZero.Collision.SideDetectors;
using SprintZero.Iceball;

namespace SprintZero.Collision
{
    public class CollisionDetection
    {
        private List<IGameObject> gameObjects { get; set; }
        private List<IGameObject> onScreenObjects { get; set; }
        private List<IEnemy> gameEnemies { get; set; }
        private List<IItem> gameItems { get; set; }
        private List<FireballObject> gameFireballs { get; set; }
        private List<IceballObject> gameIceballs { get; set; }
        private Level currentLevel;

        public CollisionDetection(Level level)
        {
            currentLevel = level;
        }

        

        public void DetectCollision(IMario mario)
        {
            gameObjects = new List<IGameObject>(currentLevel.GetObjects());
            gameObjects.AddRange(currentLevel.BigFloorRectangles);
            onScreenObjects = new List<IGameObject>(currentLevel.GetOnScreenObjects());
            onScreenObjects.AddRange(currentLevel.BigFloorRectangles);
            gameEnemies = new List<IEnemy>(currentLevel.GetEnemies());
            gameItems = new List<IItem>(currentLevel.GetItems());
            gameFireballs = new List<FireballObject>(currentLevel.GetFireballs());
            gameIceballs = new List<IceballObject>(currentLevel.GetIceballs());
            Rectangle marioRectangle = mario.RetrieveMarioRectangle();
            Rectangle extendedMarioRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y, marioRectangle.Width, marioRectangle.Height + 2);
            List<IGameObject> marioFloorCollisions = new List<IGameObject>();
            List<IGameObject> multipleCollision = new List<IGameObject>();

            //checking for mario collisions
            foreach (IGameObject collidedObject in onScreenObjects)
            {
                Rectangle collidedObjectRectangle = collidedObject.GetHitBox();
                if (marioRectangle.Intersects(collidedObjectRectangle))
                {
                    if (collidedObject is IBlock)
                    {
                        mario.onPipe = false;
                        multipleCollision.Add(collidedObject);
                    }
                    else if (collidedObject is IPipe)
                    {
                        MasterCollisionResponder.PipeCollision(mario, collidedObject);
                    }
                    else if (collidedObject is FlagPole flag)
                    {
                        flag.SideCollisionResponse();
                        flag.GivePoints((int)mario.Position.Y + 32);
                    }
                }

                //temp is a cast of the collidedOBject to IBlock so that we can access the state of the block. We do this so that Mario does not see HiddenBlocks as floor blocks
                IBlock temp = null;
                if (collidedObject is IBlock)
                    temp = (IBlock)collidedObject;
                if (extendedMarioRectangle.Intersects(collidedObjectRectangle) && 
                    CollisionSideDetector.DetectCollisionSide(extendedMarioRectangle, collidedObjectRectangle) is TopCollision &&
                    ((collidedObject is IBlock && !(temp.State is HiddenItemBlockState)) || collidedObject is IPipe))
                    marioFloorCollisions.Add(collidedObject);
            }

            //collide with only one block at a time
            IGameObject maxIntersect;
            if (multipleCollision.Count > 0)
            {
                maxIntersect = multipleCollision[0];
                foreach (IGameObject gameObject in multipleCollision)
                {
                    Rectangle collidedObjectRectangle = gameObject.GetHitBox();
                    if (marioRectangle.Intersects(collidedObjectRectangle))
                    {
                        Rectangle newIntersect = Rectangle.Intersect(marioRectangle, collidedObjectRectangle);
                        Rectangle oldMaxIntersect = Rectangle.Intersect(marioRectangle, maxIntersect.GetHitBox());
                        if (newIntersect.Width * newIntersect.Height > oldMaxIntersect.Width * oldMaxIntersect.Height)
                        {
                            maxIntersect = gameObject;
                        }
                    }
                }
                MasterCollisionResponder.BlockCollision(mario, maxIntersect);
            }
            //mario collide with items
            foreach(IItem item in gameItems)
            {
                Rectangle collidedObjectRectangle = item.GetHitBox();
                if (marioRectangle.Intersects(collidedObjectRectangle))
                {
                    MasterCollisionResponder.ItemCollision(mario, item);
                }
            }
            //mario collide with enemies
            foreach (IEnemy enemy in gameEnemies)
            {
                Rectangle collidedEnemyRectangle = enemy.GetHitBox();
                if (marioRectangle.Intersects(collidedEnemyRectangle))
                {
                    MasterCollisionResponder.EnemyCollision(mario, enemy);
                }
            }

            if (marioFloorCollisions.Count == 0 && !mario.isJumping)
                mario.Fall();
            if (marioFloorCollisions.Count > 0 && mario.isFalling)
                mario.Land();

            //checking for enemy collisions
            foreach (IEnemy enemy in gameEnemies)
            {
                Rectangle enemyRectangle = enemy.GetHitBox();
                List<IGameObject> enemyFloorCollisions = new List<IGameObject>();
                foreach (IGameObject collidedObject in gameObjects)
                {
                    if (!enemy.Equals(collidedObject))
                    {
                        Rectangle collidedObjectRectangle = collidedObject.GetHitBox();
                        if (enemyRectangle.Intersects(collidedObjectRectangle))
                        {
                            if (collidedObject is IPipe || ((collidedObject is IBlock block) && !(block.State is HiddenItemBlockState)))
                            {
                                MasterCollisionResponder.EnemyEnvironmentCollision(enemy, collidedObject);
                            }
                        }
                        Rectangle extendedEnemyRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y, enemyRectangle.Width, enemyRectangle.Height + 2);
                        if (extendedEnemyRectangle.Intersects(collidedObjectRectangle) && (collidedObject is IBlock || collidedObject is IPipe))
                        {
                            if ((collidedObject is IBlock block) && !(block.State is HiddenItemBlockState))
                                enemyFloorCollisions.Add(collidedObject);
                        }

                    }
                }
                foreach(IEnemy collidedObject in gameEnemies)
                {
                    if(!enemy.Equals(collidedObject) && enemyRectangle.Intersects(collidedObject.GetHitBox()))
                        MasterCollisionResponder.EnemyEnvironmentCollision(enemy, collidedObject);
                }

                //if the enemy's extended box did not have any floor collisions, the enemy should be falling
                if (enemyFloorCollisions.Count == 0)
                    enemy.IsFalling = true;
            }

            //checking for item collisions
            foreach (IItem item in gameItems) {
                IGameObject obj = item;
                Rectangle itemRectangle = obj.GetHitBox();
                {
                    List<IGameObject> itemFloorCollisions = new List<IGameObject>();
                    foreach (IGameObject collidedObject in gameObjects)
                    {
                        if (!item.Equals(collidedObject))
                        {
                            Rectangle collidedObjectRectangle = collidedObject.GetHitBox();
                            if (itemRectangle.Intersects(collidedObjectRectangle))
                            {
                                if (collidedObject is IPipe || ((collidedObject is IBlock block) && !(block.State is HiddenItemBlockState)))
                                    MasterCollisionResponder.ItemEnvironmentCollision(item, collidedObject);
                            }

                            Rectangle extendedItemRectangle = new Rectangle(itemRectangle.X, itemRectangle.Y, itemRectangle.Width, itemRectangle.Height + 2);
                            if (extendedItemRectangle.Intersects(collidedObjectRectangle))
                            {
                                if ((collidedObject is IBlock block) && !(block.State is HiddenItemBlockState))
                                {
                                    itemFloorCollisions.Add(collidedObject); 
                                }
                            }

                        }
                    }

                    //if the item's extended box did not have any floor collisions, the item should be falling
                    if (itemFloorCollisions.Count == 0)
                        item.IsFalling = true;
                }

            }

            //checking for fireball and iceball collisions
            foreach (FireballObject fireball in gameFireballs)
            {
                MasterCollisionResponder.FireballCollision(fireball);
            }
            foreach (IceballObject fireball in gameIceballs)
            {
                MasterCollisionResponder.IceballCollision(fireball);
            }
        }
    }
}
