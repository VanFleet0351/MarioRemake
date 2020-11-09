﻿using SprintZero.Decorator;
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

namespace SprintZero.MarioStatePattern.MarioStates
{
    class RightBigStandingMarioState : IMarioState
    {
        private Mario mario;

        public RightBigStandingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = true;
            mario.sprite = new RightBigStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftBigStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightBigRunningMarioState(mario);
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
            mario.State = new RightFireStandingMarioState(mario);
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
            mario.State = new RightIceStandingMarioState(mario);
        }
    }
}
