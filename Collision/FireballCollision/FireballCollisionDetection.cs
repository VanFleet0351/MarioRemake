using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using System.Collections.Generic;
using SprintZero.Collision.FireballCollision;
using SprintZero.Fireball;
using SprintZero.Levelmanager;

namespace SprintZero.Collision
{
    public static class FireballCollisionDetection
    {
        public static void DetectCollision(FireballObject fireball)
        {
            List<IGameObject> gameObjects = new List<IGameObject>(Game1.Instance.currentState.Level.GetObjects());
            gameObjects.AddRange(Game1.Instance.currentState.Level.BigFloorRectangles);
            List<IEnemy> enemies = new List<IEnemy>(Game1.Instance.currentState.Level.GetEnemies());
            Rectangle fireballRectangle = fireball.GetHitBox();

            foreach (IGameObject collidedObject in gameObjects)
            {
                Rectangle collidedObjectRectangle = collidedObject.GetHitBox();
                if (fireballRectangle.Intersects(collidedObjectRectangle))
                {
                    if (collidedObject is IBlock)
                    {
                        FireballBlockCollisionResponder.FireballCollideWithBlock(fireball, collidedObject);
                    }
                    else if (collidedObject is IPipe)
                    {
                        FireballPipeCollisionResponder.FireballCollideWithPipe(fireball, (IPipe)collidedObject, Game1.Instance.currentState.Level);
                    }
                }
                
            }
            foreach (IEnemy enemy in enemies)
            {
                Rectangle enemyRectangle = enemy.GetHitBox();
                if (fireballRectangle.Intersects(enemyRectangle))
                {
                    Game1.Instance.currentState.Level.AddObject(new FireballExpolsion((int)fireball.Position.X, (int)fireball.Position.Y));
                    FireballEnemyCollisionResponder.FireballCollideWithEnemy(fireball, enemy);
                }
            }
        }
    }
}
