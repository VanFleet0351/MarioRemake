using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.Enemies;
using SprintZero.Enemies.KoopaStates;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;

namespace SprintZero.Collision
{
    static class EnemyCollisionWithEnvironmentResponder
    {
        public static void EnemyCollideWithEnvironment(IEnemy enemy, IGameObject environment)
        {
            Rectangle enemyRectangle = enemy.GetHitBox();
            Rectangle environmentRectangle = environment.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(enemyRectangle, environmentRectangle);
            if (collisionSide is RightCollision)
            {
                //let koopa shells kill
                if (environment is Koopa koopa)
                {
                    if (koopa.State is LeftSlidingShellState || koopa.State is RightSlidingShellState)
                    {
                        enemy.BeFlipped();
                        SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
                    }
                    else if (!(enemy is LeftSlidingShellState || enemy is RightSlidingShellState))
                    {
                        environment.SideCollisionResponse();
                    }
                }
                else if (environment is IEnemy collidedEnemy)
                {
                    if(enemy.State is LeftSlidingShellState || enemy.State is RightSlidingShellState)
                    {
                        collidedEnemy.BeFlipped();
                        SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
                    }
                    else if (!(enemy is LeftSlidingShellState || enemy is RightSlidingShellState))
                    {
                        environment.SideCollisionResponse();
                    }
                }
                else
                {
                    enemy.SideCollisionResponse();
                }

                enemy.Position = new Vector2(enemy.Position.X - collisionSide.CollisionIntersection.Width, enemy.Position.Y);
                
               
            }
            else if (collisionSide is LeftCollision)
            {
                //let koopa shells kill
                if (environment is Koopa koopa)
                {
                    if (koopa.State is LeftSlidingShellState || koopa.State is RightSlidingShellState)
                    {
                        enemy.BeFlipped();
                        SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
                    }
                    else if(!(enemy is LeftSlidingShellState || enemy is RightSlidingShellState))
                    {
                        environment.SideCollisionResponse();
                    }
                }
                else if (environment is IEnemy collidedEnemy)
                {
                    if (enemy.State is LeftSlidingShellState || enemy.State is RightSlidingShellState)
                    {
                        collidedEnemy.BeFlipped();
                    }
                    else if(!(enemy is LeftSlidingShellState || enemy is RightSlidingShellState))
                    {
                        environment.SideCollisionResponse();
                    }
                    
                }
                else
                {
                    enemy.SideCollisionResponse();
                }
                enemy.Position = new Vector2(enemy.Position.X + collisionSide.CollisionIntersection.Width, enemy.Position.Y);
            }
            else if (collisionSide is TopCollision && (environment is IBlock || environment is IPipe))
            {
                if (environment is IBlock block)
                {
                    if (block.WasHit)
                    {
                        enemy.BeFlipped();
                        SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
                    }
                    if (!(block.State is HiddenItemBlockState))
                    {
                        enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - collisionSide.CollisionIntersection.Height);
                        enemy.IsFalling = false;
                    }
                }
                else
                {
                    enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - collisionSide.CollisionIntersection.Height);
                    enemy.IsFalling = false;
                }
            }
            else if (collisionSide is TopCollision && environment is IEnemy)
            {
                IEnemy collidedEnemy = (IEnemy)environment;
                collidedEnemy.BeFlipped();
            }
        }
    }
}
