using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class DeadMarioState : IMarioState
    {
        private Mario mario;
        private int respawnTimer;
        private float speed = 15.0F;
        private float gravity = -1.5F;
        private float dy = 0;
        private float dt = 0.6F;

        public DeadMarioState(Mario mario)
        {
            this.mario = mario;
            mario.sprite = new DeadMarioSprite(mario);
            respawnTimer = 0;
            mario.physicsObject.dx = 0;
            mario.physicsObject.runSpeed = 0;
        }

        public void Die()
        {
        }

        public void GetHit()
        {
        }

        public void WalkLeft()
        {
        }

        public void Big()
        {
        }

        public void Jump()
        {       
        }

        public void WalkRight()
        {        
        }

        public void Crouch()
        {
        }

        public void Update()
        {
            dy = (speed * dt) + (0.5F * gravity * dt * dt);
            speed = speed + (gravity * dt);
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - dy);
            respawnTimer++;
        }

        public void Fire()
        {
        }

        public void Star()
        {

        }

        public void Idle()
        {
        }

        public void Fall()
        {
        }

        public void Land()
        {
        }

        public void Sprint()
        {
        }

        public void Climb()
        {
        }
        public void Ice()
        {
        }
    }
}
