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
using SprintZero.ScreenCamera;

namespace SprintZero.MarioStatePattern
{
    class LeftIceFallingMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public LeftIceFallingMarioState(Mario mario)
        {
            this.mario = mario;

            if (!mario.isJumping)
                mario.physicsObject.aerialSpeed = 0;

            mario.direction = false;
            mario.isJumping = false;
            mario.isFalling = true;
            mario.IceMario = true;
            mario.sprite = new LeftIceJumpingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.physicsObject.Accelerate();
        }

        public void WalkRight()
        {
            mario.physicsObject.SlowDownInAir();
        }

        public void Jump()
        {
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.IceMario = false;
            mario.State = new LeftSmallFallingMarioState(mario);
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
            if (mario.Position.X >= PlayerOneCamera.Instance.LeftBound)
            {
                if (isSprinting)
                    mario.physicsObject.Sprint(false);
                else
                    mario.physicsObject.Run(false);
            }
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
            mario.State = new LeftIceFallingMarioState(mario);
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
            mario.State = new LeftIceSlidingMarioState(mario);
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
