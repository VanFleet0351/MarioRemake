using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Iceball;
using SprintZero.Levelmanager;

namespace SprintZero.Collision
{
    public static class IceballBlockCollisionResponder
    {
        public static void IceballCollideWithBlock(IceballObject iceball, IGameObject block)
        {
            Level level = Game1.Instance.currentState.Level;
            Rectangle iceballRectangle = iceball.GetHitBox();
            Rectangle blockRectangle = block.GetHitBox();
            IBlock castBlock = (IBlock) block;
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(iceballRectangle, blockRectangle);

            if (castBlock.State is HiddenItemBlockState)
                return;

            if (collisionSide is TopCollision)
            {
                iceball.Position = new Vector2(iceball.Position.X, iceball.Position.Y-collisionSide.CollisionIntersection.Height);
                iceball.BounceOffGround();
            }
            else if (collisionSide is RightCollision)
            {
                level.AddObject(new IceballExplosion((int)iceball.Position.X, (int)iceball.Position.Y));
                iceball.Explode();
            }
            else if (collisionSide is LeftCollision)
            {
                level.AddObject(new IceballExplosion((int)iceball.Position.X, (int)iceball.Position.Y));
                iceball.Explode();

            }
            else if (collisionSide is BottomCollision)
            {
                level.AddObject(new IceballExplosion((int)iceball.Position.X, (int)iceball.Position.Y));
                iceball.PhysicsObject.dy = 10.0F;
            }
        }
    }
}
