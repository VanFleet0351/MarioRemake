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
    class LeftSmallStandingMarioState : IMarioState
    {
        private Mario mario;

        public LeftSmallStandingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = false;
            mario.sprite = new LeftSmallStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftSmallRunningMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightSmallStandingMarioState(mario);
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
        }

        public void Update()
        {
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftFireStandingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new LeftSmallStandingMarioState(mario);
        }

        public void Idle()
        {
            mario.physicsObject.ResetX();
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
        }
        public void Climb()
        {
            mario.State = new ClimbingSmallMarioState(mario);
        }
        public void Ice()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftIceStandingMarioState(mario);
        }
    }
}
