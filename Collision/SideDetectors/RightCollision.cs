using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.Collision.SideDetectors
{
    internal class RightCollision : ICollision
    {
        public Rectangle CollisionIntersection { get; }

        public RightCollision(Rectangle intersection)
        {
            CollisionIntersection = intersection;
        }
    }
}
