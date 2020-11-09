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
using SprintZero.Decorator;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class RightSmallRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public RightSmallRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.sprite = new RightSmallRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new RightSmallStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.physicsObject.Accelerate();
        }

        public void Jump()
        {
            mario.State = new RightSmallJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Big()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightBigStandingMarioState(mario);
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Crouch()
        {
            this.Idle();
        }

        public void Update()
        {
            if (isSprinting)
                mario.physicsObject.Sprint(true);
            else
                mario.physicsObject.Run(true);
            isSprinting = false;
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightFireStandingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightSmallRunningMarioState(mario);
        }

        public void Idle()
        {
            mario.State = new RightSmallSlidingMarioState(mario);
        }
        public void Fall()
        {
            mario.State = new RightSmallFallingMarioState(mario);
        }

        public void Land()
        {
        }

        public void Sprint()
        {
            isSprinting = true;
        }
        public void Climb()
        {
            mario.State = new ClimbingSmallMarioState(mario);
        }
        public void Ice()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightIceRunningMarioState(mario);
        }
    }
}
