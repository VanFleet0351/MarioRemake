using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Fireball;
using SprintZero.Levelmanager;

namespace SprintZero.Collision
{
    public static class FireballBlockCollisionResponder
    {
        public static void FireballCollideWithBlock(FireballObject fireball, IGameObject block)
        {
            Level level = Game1.Instance.currentState.Level;
            Rectangle fireballRectangle = fireball.GetHitBox();
            Rectangle blockRectangle = block.GetHitBox();
            IBlock castBlock = (IBlock) block;
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(fireballRectangle, blockRectangle);

            if (castBlock.State is HiddenItemBlockState)
                return;

            if (collisionSide is TopCollision)
            {
                fireball.Position = new Vector2(fireball.Position.X, fireball.Position.Y-collisionSide.CollisionIntersection.Height);
                fireball.BounceOffGround();
            }
            else if (collisionSide is RightCollision)
            {
                level.AddObject(new FireballExpolsion((int)fireball.Position.X, (int)fireball.Position.Y));
                fireball.Explode();
            }
            else if (collisionSide is LeftCollision)
            {
                level.AddObject(new FireballExpolsion((int)fireball.Position.X, (int)fireball.Position.Y));
                fireball.Explode();

            }
            else if (collisionSide is BottomCollision)
            {
                level.AddObject(new FireballExpolsion((int)fireball.Position.X, (int)fireball.Position.Y));
                fireball.PhysicsObject.dy = 10.0F;
            }
        }
    }
}
