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

namespace SprintZero.MarioStatePattern
{
    class RightSmallJumpingMarioState : IMarioState
    {
        private Mario mario;
        private bool stillJumping = true;
        private bool isSprinting;

        public RightSmallJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.sprite = new RightSmallJumpingMarioSprite(mario);
            SoundFactory.Instance.Play(SoundFactory.Effects.Jump);
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
            mario.physicsObject.Jump();

            stillJumping = true;
            mario.physicsObject.jumptick++;
            if (mario.physicsObject.jumptick > 60)
                mario.State = new RightSmallFallingMarioState(mario);
        }


        public void GetHit()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Big()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightBigJumpingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightSmallJumpingMarioState(mario);
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

            if (!stillJumping)
                mario.Fall();
            stillJumping = false;
        }

        public void Fire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightFireJumpingMarioState(mario);
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
            isSprinting = true;
        }
        public void Climb()
        {
            mario.State = new ClimbingSmallMarioState(mario);
        }
        public void Ice()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 32);
            mario.State = new RightIceJumpingMarioState(mario);
        }
    }
}
