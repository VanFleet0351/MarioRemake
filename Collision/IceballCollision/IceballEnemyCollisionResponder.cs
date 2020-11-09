using Microsoft.Xna.Framework;
using SprintZero.Iceball;
using SprintZero.Interfaces;

namespace SprintZero.Collision.FireballCollision
{
    static class IceballEnemyCollisionResponder
    {
        public static void IceballCollideWithEnemy(IceballObject iceball, IEnemy enemy)
        {
            iceball.Explode();
            enemy.Freeze();
        }
    }
}
