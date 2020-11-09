using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Enemies
{
    class EnemyPhysicsObject : IEnemyPhysicsObject
    {
        public IMario mario { get; set; }
        public IEnemy Enemy { get; set; }
        public float gravity { get; set; }
        public float aerialSpeed { get; set; }
        public float maxFallSpeed { get; set; }
        public float runAcceleration { get; set; }
        public float runSpeed { get; set; }
        public float maxRunSpeed { get; set; }
        public float dx { get; set; }
        public float dy { get; set; }
        public float dt { get; set; }
        public int jumptick { get; set; }

        public EnemyPhysicsObject(IEnemy enemy)
        {
            Enemy = enemy;
            gravity = -1.8F;
            aerialSpeed = 0;
            maxFallSpeed = 7.0F;
            dt = 0.5F;
            dy = 0;
        }

        public void Fall()
        {
            if (aerialSpeed <= maxFallSpeed)
            {
                dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);
                aerialSpeed = aerialSpeed + (gravity * dt);
            }
            else
            {
                aerialSpeed = maxFallSpeed;
                dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);
            }
            Enemy.Position = new Vector2(Enemy.Position.X, Enemy.Position.Y - dy);
        }

        public void Jump()
        {
        }

        public void Reset(bool direction)
        {
            aerialSpeed = 0;
            dy = 0;
        }

        public void Running(bool direction)
        {
        }

        public void Update()
        {

        }

        public void SlowDownInAir(bool direction)
        {
        }
    }
}
