using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.Interfaces;
using SprintZero.Decorator;
using SprintZero.Enemies.KoopaStates;
using System.Diagnostics;

namespace SprintZero.Collision
{
    public static class EnemyCollisionResponder
    {
        public static void MarioCollideWithEnemy (IMario mario, IGameObject enemy)
        {
            Rectangle marioRectangle = mario.RetrieveMarioRectangle();
            Rectangle enemyRectangle = enemy.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(marioRectangle, enemyRectangle);
            IEnemy collidedEnemy = (IEnemy) enemy;
            if (collisionSide is RightCollision)
            {
                mario.Position = new Vector2(mario.Position.X - collisionSide.CollisionIntersection.Width, mario.Position.Y);
                if (!(mario is StarMario) && !(collidedEnemy.State is StompedKoopaState))
                {
                    new ShrunkenMario(mario, Game1.Instance);
                }
                if (!(collidedEnemy.State is StompedKoopaState))
                {
                    mario.GetHit();
                }
                                            collidedEnemy.HitFromLeft((IGameObject) mario);
            }
            else if (collisionSide is LeftCollision)
            {
                mario.Position = new Vector2(mario.Position.X + collisionSide.CollisionIntersection.Width, mario.Position.Y);
                if (!(mario is StarMario) &&  !(collidedEnemy.State is StompedKoopaState))
                {
                    new ShrunkenMario(mario, Game1.Instance);
                }
                if (!(collidedEnemy.State is StompedKoopaState))
                {
                    mario.GetHit();
                }
                collidedEnemy.HitFromRight((IGameObject) mario);


            }
            else if (collisionSide is TopCollision)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - collisionSide.CollisionIntersection.Height - 5);
                mario.physicsObject.aerialSpeed = 10;
                mario.physicsObject.dy = 0;
                mario.physicsObject.Jump();
                IEnemy hitEnemy = (IEnemy)enemy;
                hitEnemy.BeStomped();

            }
            else if (collisionSide is BottomCollision)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + collisionSide.CollisionIntersection.Height);
                if (!(collidedEnemy.State is StompedKoopaState))
                {
                    mario.GetHit();
                }
            }
        }
    
    }
}
