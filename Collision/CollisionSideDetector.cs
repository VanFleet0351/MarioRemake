using Microsoft.Xna.Framework;
using SprintZero.Collision.SideDetectors;
using SprintZero.Interfaces;

namespace SprintZero.Collision
{
    class CollisionSideDetector
    {
        private CollisionSideDetector()
        {
        }

        public static ICollision DetectCollisionSide(Rectangle instigatingRectangle, Rectangle receivingRectangle)
        {
            Rectangle collisionIntersection = Rectangle.Intersect(instigatingRectangle, receivingRectangle);
            if (collisionIntersection.Height > collisionIntersection.Width)
            {
                if (instigatingRectangle.Right > receivingRectangle.Left && instigatingRectangle.Right < receivingRectangle.Right)
                {
                    return new RightCollision(collisionIntersection);
                }
                
                return new LeftCollision(collisionIntersection);
                
            }
            else 
            {
                if (instigatingRectangle.Bottom > receivingRectangle.Top && instigatingRectangle.Bottom < receivingRectangle.Bottom)
                {
                    return new TopCollision(collisionIntersection);
                }
                
                return new BottomCollision(collisionIntersection);
                
            }
        }
    }
}
