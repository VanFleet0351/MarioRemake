using SprintZero.Interfaces;
using SprintZero.MarioStatePattern.MarioStates;
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
using SprintZero.Levelmanager;

namespace SprintZero.MarioStatePattern
{
    class RightIceJumpingMarioState : IMarioState
    {
        private Mario mario;
        private bool stillJumping = true;
        private bool isSprinting;

        public RightIceJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.IceMario = true;
            mario.sprite = new RightIceJumpingMarioSprite(mario);
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
                mario.Fall();
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.IceMario = false;
            mario.State = new RightSmallJumpingMarioState(mario);
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

            if (!stillJumping)
                mario.Fall();
            stillJumping = false;

            if (mario.powerCooldown > 0)
                mario.powerCooldown--;
        }

        public void Fire()
        {
        }

        public void Star()
        {
            mario.State = new RightIceJumpingMarioState(mario);
        }

        public void Idle()
        {

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
