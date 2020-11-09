using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.Collision.SideDetectors
{
    internal class TopCollision : ICollision
    {
        public Rectangle CollisionIntersection { get; }

        public TopCollision(Rectangle intersection)
        {
            CollisionIntersection = intersection;
        }
    }
}
