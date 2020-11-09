using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Decorator;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftBigStandingMarioState : IMarioState
    {
        private Mario mario;

        public LeftBigStandingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = false;
            mario.sprite = new LeftBigStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftBigRunningMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightBigStandingMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftBigJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.State = new LeftSmallStandingMarioState(mario);
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
            mario.State = new LeftBigCrouchingMarioState(mario);
        }

        public void Fire()
        {
            mario.State = new LeftFireStandingMarioState(mario);
        }

        public void Star()
        {
        }
        public void Update()
        {
        }

        public void Idle()
        {
            mario.physicsObject.ResetX();
        }

        public void Fall()
        {
            mario.State = new LeftBigFallingMarioState(mario);
        }

        public void Land()
        {
        }

        public void Sprint()
        {
        }
        public void Climb()
        {
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new LeftIceStandingMarioState(mario);
        }
    }
}
