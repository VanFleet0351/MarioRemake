using SprintZero.Interfaces;
using SprintZero.Player;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SprintZero.Sprites.MarioSprites;
using SprintZero.Decorator;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class RightIceRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public RightIceRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.IceMario = true;
            mario.sprite = new RightIceRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new RightIceStandingMarioState(mario);
        }

        public void WalkRight()
        {
            mario.physicsObject.Accelerate();
        }

        public void Jump()
        {
            mario.State = new RightIceJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.IceMario = false;
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
            mario.State = new RightIceCrouchingMarioState(mario);
        }

        public void Update()
        {
            if (isSprinting)
                mario.physicsObject.Sprint(true);
            else
                mario.physicsObject.Run(true);
            isSprinting = false;

            if (mario.powerCooldown > 0)
                mario.powerCooldown--;
        }

        public void Fire()
        {
        }

        public void Star()
        {
            mario.State = new RightIceRunningMarioState(mario);
        }

        public void Idle()
        {
            mario.State = new RightIceSlidingMarioState(mario);
        }
        public void Fall()
        {
            mario.State = new RightIceFallingMarioState(mario);
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
            mario.State = new ClimbingIceMarioState(mario);
        }
        public void Ice()
        {
        }
    }
}
