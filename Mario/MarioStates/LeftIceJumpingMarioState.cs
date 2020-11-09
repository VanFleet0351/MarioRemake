using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.MarioStatePattern.MarioStates;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern
{
    class LeftIceJumpingMarioState : IMarioState
    {
        private Mario mario;
        private bool stillJumping = true;
        private bool isSprinting;

        public LeftIceJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.IceMario = true;
            mario.sprite = new LeftIceJumpingMarioSprite(mario);
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
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.IceMario = false;
            mario.State = new LeftSmallJumpingMarioState(mario);
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
        }
        public void Idle()
        {

        }

        public void Fall()
        {
            mario.State = new LeftIceFallingMarioState(mario);
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
