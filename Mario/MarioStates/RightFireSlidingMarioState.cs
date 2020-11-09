using SprintZero.Interfaces;
using SprintZero.Player;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Sprites.MarioSprites;
using SprintZero.Decorator;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class RightFireSlidingMarioState : IMarioState
    {
        private Mario mario;
        public RightFireSlidingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = true;
            mario.sprite = new RightFireStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftFireStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightFireRunningMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new RightFireJumpingMarioState(mario);
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
            mario.State = new RightFireCrouchingMarioState(mario);
        }

        public void Update()
        {
            if (mario.powerCooldown > 0)
                mario.powerCooldown--;
        }

        public void Fire()
        {
        }

        public void Star()
        {
            mario.State = new RightFireStandingMarioState(mario);
        }
        public void Idle()
        {
            mario.physicsObject.MaintainMomentum(mario.direction);

            if (mario.physicsObject.dx == 0)
                mario.State = new RightFireStandingMarioState(mario);
        }
        public void Fall()
        {
            mario.State = new RightFireFallingMarioState(mario);
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
            mario.State = new ClimbingFireMarioState(mario);
        }
        public void Ice()
        {
        }
    }
}
