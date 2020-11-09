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

namespace SprintZero.MarioStatePattern
{
    class RightSmallSlidingMarioState : IMarioState
    {
        private Mario mario;

        public RightSmallSlidingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = true;
            mario.sprite = new RightSmallStandingMarioSprite(mario);
        }
        public void WalkLeft()
        {
            mario.State = new LeftSmallStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightSmallRunningMarioState(mario);
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
        }

        public void Update()
        {
            mario.physicsObject.MaintainMomentum(mario.direction);

            if (mario.physicsObject.dx == 0)
                mario.State = new RightSmallStandingMarioState(mario);
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightFireStandingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightSmallStandingMarioState(mario);
        }

        public void Idle()
        {
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
            this.Idle();
        }
        public void Climb()
        {
            mario.State = new ClimbingSmallMarioState(mario);
        }
        public void Ice()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightIceSlidingMarioState(mario);
        }
    }
}
