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
    class RightBigCrouchingMarioState : IMarioState
    {
        private Mario mario;

        public RightBigCrouchingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 20);
            mario.physicsObject.dx = 0;
            mario.physicsObject.runSpeed = 0;
            mario.sprite = new RightBigCrouchingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftBigCrouchingMarioState(mario);
        }

        public void WalkRight()
        {
        }

        public void Jump()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new RightBigJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 12);
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
        }

        public void Fire()
        {
            mario.State = new RightFireCrouchingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightBigCrouchingMarioState(mario);
        }
        public void Update()
        {
        }

        public void Idle()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new RightBigStandingMarioState(mario);
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
        }
        public void Climb()
        {
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new RightIceCrouchingMarioState(mario);
        }
    }
}
