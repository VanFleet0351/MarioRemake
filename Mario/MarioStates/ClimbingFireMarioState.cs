using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.MarioStatePattern.MarioStates;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Decorator;
using SprintZero.ScreenCamera;

namespace SprintZero.MarioStatePattern
{
    class ClimbingFireMarioState : IMarioState
    {
        private Mario mario;

        public ClimbingFireMarioState(Mario mario)
        {
            this.mario = mario;

            if (!mario.isJumping)
                mario.physicsObject.aerialSpeed = 0;
            
            mario.isJumping = false;
            mario.isFalling = false;
            mario.sprite = new FireClimbingMarioSprite(mario);
        }

        public void WalkLeft()
        {
        }

        public void WalkRight()
        {
            mario.State = new RightFireRunningMarioState(mario);
        }

        public void Jump()
        {
        }


        public void GetHit()
        {
        }

        public void Big()
        {
        }

        public void Die()
        {
        }

        public void Crouch()
        {
        }

        public void Update()
        {
            mario.Position += new Vector2(0, 1);
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
