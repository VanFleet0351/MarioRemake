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
using SprintZero.Levelmanager;
using SprintZero.ScreenCamera;

namespace SprintZero.MarioStatePattern
{
    class LeftSmallJumpingMarioState : IMarioState
    {
        private Mario mario;
        private bool stillJumping = true;
        private bool isSprinting;

        public LeftSmallJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.sprite = new LeftSmallJumpingMarioSprite(mario);
            SoundFactory.Instance.Play(SoundFactory.Effects.Jump);
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
            mario.physicsObject.Jump();

            stillJumping = true;
            mario.physicsObject.jumptick++;
            if (mario.physicsObject.jumptick > 60)
                mario.Fall();
        }

        public void GetHit()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Big()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftBigJumpingMarioState(mario);
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

            if (!stillJumping)
                mario.Fall();
            stillJumping = false;
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new LeftFireJumpingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new LeftSmallJumpingMarioState(mario);
        }

        public void Idle()
        {

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
            mario.State = new LeftIceJumpingMarioState(mario);
        }
    }
}
