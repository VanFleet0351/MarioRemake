using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Items;

namespace SprintZero.Collision
{
    public static class ItemCollisionWithEnvironmentResponder
    {
        public static void ItemCollideWithEnvironment(IItem item, IGameObject environment)
        {
            Rectangle itemRectangle = item.GetHitBox();
            Rectangle environmentRectangle = environment.GetHitBox();
            ICollision collisionSide = CollisionSideDetector.DetectCollisionSide(itemRectangle, environmentRectangle);
            if (collisionSide is RightCollision)
            {
                item.SideCollisionResponse();
                item.Position = new Vector2(item.Position.X - collisionSide.CollisionIntersection.Width, item.Position.Y);
            }
            else if (collisionSide is LeftCollision)
            {
                item.SideCollisionResponse();
                item.Position = new Vector2(item.Position.X + collisionSide.CollisionIntersection.Width, item.Position.Y);
            }
            else if (collisionSide is TopCollision)
            {
                if (environment is IBlock block)
                {
                    if (block.WasHit)
                    {
                        item.SideCollisionResponse();
                    }
                    if (!(block.State is HiddenItemBlockState))
                    {
                        item.Position = new Vector2(item.Position.X, item.Position.Y - collisionSide.CollisionIntersection.Height);
                        item.IsFalling = false;
                    }
                    else
                    {
                        item.IsFalling = true;
                    }
                }
                else
                {
                    item.Position = new Vector2(item.Position.X, item.Position.Y - collisionSide.CollisionIntersection.Height);
                    item.IsFalling = false;
                }
            }

        }
    }
}

