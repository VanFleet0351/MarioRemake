using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Fireball
{
    public class FireballPhysicsObject
    {
        public FireballObject fireball { get; set; }
        public float ySpeed { get; set; }
        public float maxSpeed { get; set; }
        public float gravity { get; set; }
        public bool direction { get; set; }
        public float dx { get; set; }
        public float dy { get; set; }
        public float dt { get; set; }

        public FireballPhysicsObject(FireballObject fireball, bool direction)
        {
            this.fireball = fireball;
            ySpeed = 0;
            maxSpeed = 15;
            gravity = 2.0F;
            dy = 0;
            dt = 0.5F;
            if (direction)
                dx = 6.0F;
            else
                dx = -6.0F;
        }

        public void Update()
        {
            //get dy
            dy = (ySpeed * dt) + (0.5F * gravity * dt * dt); ;
            if(ySpeed < maxSpeed)
                ySpeed = ySpeed + (gravity * dt);
            fireball.Position = new Vector2(fireball.Position.X + dx, fireball.Position.Y + dy);
        }
    }
}
