using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.Collision.SideDetectors
{
    internal class BottomCollision : ICollision
    {
        public Rectangle CollisionIntersection { get; }

        public BottomCollision(Rectangle intersection)
        {
            CollisionIntersection = intersection;
        }
    }
}
