using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.Fireball;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;

namespace SprintZero.Collision.FireballCollision
{
    public static class FireballPipeCollisionResponder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void FireballCollideWithPipe(FireballObject fireball, IPipe pipe, Level level)
        {
            Rectangle fireballRectangle = fireball.GetHitBox();
            Rectangle pipeRectangle = pipe.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(fireballRectangle, pipeRectangle);

            if (collisionSide is TopCollision)
            {
                fireball.BounceOffGround();
            }
            else
            {
                level.AddObject(new FireballExpolsion((int)fireball.Position.X, (int)fireball.Position.Y));
                fireball.Explode();
            }
        }
    }
}
