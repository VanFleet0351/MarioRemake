using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SprintZero.Decorator;
using System.Text;
using System.Threading.Tasks;
using SprintZero.ScreenCamera;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftSmallRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public LeftSmallRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.sprite = new LeftSmallRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.physicsObject.Accelerate();
        }

        public void WalkRight()
        {
            mario.State = new LeftSmallStandingMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftSmallJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Big()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftBigStandingMarioState(mario);
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
            if (mario.Position.X >= PlayerOneCamera.Instance.LeftBound)
            {
                if (isSprinting)
                    mario.physicsObject.Sprint(false);
                else
                    mario.physicsObject.Run(false);
            }
            isSprinting = false;
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftFireStandingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new LeftSmallRunningMarioState(mario);
        }

        public void Idle()
        {
            mario.State = new LeftSmallSlidingMarioState(mario);
        }
        public void Fall()
        {
            mario.State = new LeftSmallFallingMarioState(mario);
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
            mario.State = new LeftIceRunningMarioState(mario);
        }
    }
}
