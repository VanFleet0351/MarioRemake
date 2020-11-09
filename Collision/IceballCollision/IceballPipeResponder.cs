using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.Iceball;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;

namespace SprintZero.Collision.FireballCollision
{
    public static class IceballPipeCollisionResponder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void IceballCollideWithPipe(IceballObject iceball, IPipe pipe, Level level)
        {
            Rectangle iceballRectangle = iceball.GetHitBox();
            Rectangle pipeRectangle = pipe.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(iceballRectangle, pipeRectangle);

            if (collisionSide is TopCollision)
            {
                iceball.BounceOffGround();
            }
            else
            {
                level.AddObject(new IceballExplosion((int)iceball.Position.X, (int)iceball.Position.Y));
                iceball.Explode();
            }
        }
    }
}
