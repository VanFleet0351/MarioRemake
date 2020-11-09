using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.Collision.SideDetectors
{
    internal class LeftCollision : ICollision
    {
        public Rectangle CollisionIntersection { get; }

        public LeftCollision(Rectangle intersection)
        {
            CollisionIntersection = intersection;
        }
    }
}
