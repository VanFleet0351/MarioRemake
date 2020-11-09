using Microsoft.Xna.Framework;
using SprintZero.Fireball;
using SprintZero.Interfaces;

namespace SprintZero.Collision.FireballCollision
{
    static class FireballEnemyCollisionResponder
    {
        public static void FireballCollideWithEnemy(FireballObject fireball, IEnemy enemy)
        {
            fireball.Explode();
            enemy.BeFlipped();
        }
    }
}
