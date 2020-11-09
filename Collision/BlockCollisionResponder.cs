using Microsoft.Xna.Framework;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Collision.SideDetectors;
using SprintZero.Interfaces;
using System.Collections.Generic;

namespace SprintZero.Collision
{
    public static class BlockCollisionResponder
    {
        public static void MarioCollideWithBlock(IMario mario, IGameObject block)
        {
            Rectangle marioRectangle = mario.RetrieveMarioRectangle();
            Rectangle blockRectangle = block.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(marioRectangle, blockRectangle);
            IBlock collidedBlock = (IBlock)block;

            if (collisionSide is RightCollision && !(collidedBlock.State is HiddenItemBlockState))
            {
                mario.Position = new Vector2(mario.Position.X - collisionSide.CollisionIntersection.Width, mario.Position.Y);
            }
            else if (collisionSide is LeftCollision && !(collidedBlock.State is HiddenItemBlockState))
            {
                mario.Position = new Vector2(mario.Position.X + collisionSide.CollisionIntersection.Width, mario.Position.Y);
            }
            else if (collisionSide is TopCollision && !(collidedBlock.State is HiddenItemBlockState))
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - collisionSide.CollisionIntersection.Height);
            }
            else if (collisionSide is BottomCollision)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + collisionSide.CollisionIntersection.Height);
                if ((block is IBlock hitBlock) && !mario.isFalling)
                {
                    
                    if (mario.BigMario)
                    {
                        hitBlock.BeHit();
                    }
                    else
                    {
                        hitBlock.BeBumped();
                    }
                    mario.isJumping = false;
                    mario.isFalling = true;
                    mario.physicsObject.aerialSpeed = 0;
                }
            }
        }
    }
}
