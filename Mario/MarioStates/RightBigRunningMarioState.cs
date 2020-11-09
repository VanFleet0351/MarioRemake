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
using SprintZero.Decorator;
using System.Threading.Tasks;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class RightBigRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public RightBigRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.sprite = new RightBigRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new RightBigStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.physicsObject.Accelerate();
        }

        public void Jump()
        {
            mario.State = new RightBigJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.State = new RightSmallStandingMarioState(mario);
        }

        public void Big()
        {
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Crouch()
        {
            mario.State = new RightBigCrouchingMarioState(mario);
        }

        public void Fire()
        {
            mario.State = new RightFireRunningMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightBigRunningMarioState(mario);
        }

        public void Update()
        {
            if (isSprinting)
                mario.physicsObject.Sprint(true);
            else
                mario.physicsObject.Run(true);
            isSprinting = false;
        }

        public void Idle()
        {
            mario.State = new RightBigSlidingMarioState(mario);
        }
        public void Fall()
        {
            mario.State = new RightBigFallingMarioState(mario);
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
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new RightIceRunningMarioState(mario);
        }
    }
}
