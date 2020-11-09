using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.MarioStatePattern.MarioStates;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern
{
    class LeftBigJumpingMarioState : IMarioState
    {
        private Mario mario;
        private bool stillJumping = true;
        private bool isSprinting;

        public LeftBigJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.sprite = new LeftBigJumpingMarioSprite(mario);
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

        public void Fire()
        {
            mario.State = new  LeftFireJumpingMarioState(mario);
        }

        public void Star()
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

        public void Idle()
        {

        }

        public void Fall()
        {
            mario.State = new LeftBigFallingMarioState(mario);
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
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new LeftIceJumpingMarioState(mario);
        }
    }
}
