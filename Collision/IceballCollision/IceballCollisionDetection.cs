using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using System.Collections.Generic;
using SprintZero.Collision.FireballCollision;
using SprintZero.Iceball;
using SprintZero.Levelmanager;

namespace SprintZero.Collision
{
    public static class IceballCollisionDetection
    {
        public static void DetectCollision(IceballObject iceball)
        {
            List<IGameObject> gameObjects = new List<IGameObject>(Game1.Instance.currentState.Level.GetObjects());
            gameObjects.AddRange(Game1.Instance.currentState.Level.BigFloorRectangles);
            List<IEnemy> enemies = new List<IEnemy>(Game1.Instance.currentState.Level.GetEnemies());
            Rectangle iceballRectangle = iceball.GetHitBox();

            foreach (IGameObject collidedObject in gameObjects)
            {
                Rectangle collidedObjectRectangle = collidedObject.GetHitBox();
                if (iceballRectangle.Intersects(collidedObjectRectangle))
                {
                    if (collidedObject is IBlock)
                    {
                        IceballBlockCollisionResponder.IceballCollideWithBlock(iceball, collidedObject);
                    }
                    else if (collidedObject is IPipe)
                    {
                        IceballPipeCollisionResponder.IceballCollideWithPipe(iceball, (IPipe)collidedObject, Game1.Instance.currentState.Level);
                    }
                }
                
            }
            foreach (IEnemy enemy in enemies)
            {
                Rectangle enemyRectangle = enemy.GetHitBox();
                if (iceballRectangle.Intersects(enemyRectangle))
                {
                    Game1.Instance.currentState.Level.AddObject(new IceballExplosion((int)iceball.Position.X, (int)iceball.Position.Y));
                    IceballEnemyCollisionResponder.IceballCollideWithEnemy(iceball, enemy);
                }
            }
        }
    }
}
