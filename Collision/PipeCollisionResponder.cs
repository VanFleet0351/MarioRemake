using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Pipes;
using System.Diagnostics;

namespace SprintZero.Collision
{
    public static class PipeCollisionResponder
    {
        public static void MarioCollideWithPipe(IMario mario, IPipe pipe)
        {
            Rectangle marioRectangle = mario.RetrieveMarioRectangle();
            Rectangle pipeRectangle = pipe.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(marioRectangle, pipeRectangle);

            if (collisionSide is RightCollision)
            {
                mario.Position = new Vector2(mario.Position.X - collisionSide.CollisionIntersection.Width, mario.Position.Y);
                if (pipe is SidewaysPipe)
                {
                    SidewaysPipe enteredPipe = (SidewaysPipe)pipe;
                    enteredPipe.EnterPipe();
                }
            }
            else if (collisionSide is LeftCollision)
            {
                mario.Position = new Vector2(mario.Position.X + collisionSide.CollisionIntersection.Width, mario.Position.Y);
            }
            else if (collisionSide is TopCollision)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - collisionSide.CollisionIntersection.Height);
                if (mario.isFalling)
                    mario.Idle();
                if (pipe is PipeLargeEnterable)
                {
                    mario.onPipe = true;
                }
            }
            else if (collisionSide is BottomCollision)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + collisionSide.CollisionIntersection.Height);
            }


        }
    }
}
