﻿using Microsoft.Xna.Framework;
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
    class RightFireFallingMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public RightFireFallingMarioState(Mario mario)
        {
            this.mario = mario;

            if (!mario.isJumping)
                mario.physicsObject.aerialSpeed = 0;

            mario.direction = true;
            mario.isJumping = false;
            mario.isFalling = true;
            mario.sprite = new RightFireJumpingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.physicsObject.SlowDownInAir();
        }

        public void WalkRight()
        {
            mario.physicsObject.Accelerate();
        }

        public void Jump()
        {
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.State = new RightSmallFallingMarioState(mario);
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

        public void Update()
        {
            if (isSprinting)
                mario.physicsObject.Sprint(true);
            else
                mario.physicsObject.Run(true);
            isSprinting = false;

            mario.physicsObject.Fall();

            if (mario.powerCooldown > 0)
                mario.powerCooldown--;
        }

        public void Fire()
        {
        }
        public void Star()
        {
            mario.State = new LeftFireFallingMarioState(mario);
        }
        public void Idle()
        {
        }
        public void Fall()
        {
        }

        public void Land()
        {
            mario.isJumping = false;
            mario.isFalling = false;
            mario.physicsObject.ResetY();
            mario.State = new RightFireSlidingMarioState(mario);
        }

        public void Sprint()
        {
            isSprinting = true;
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
