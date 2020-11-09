using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.MarioStatePattern.MarioStates;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern
{
    class RightBigJumpingMarioState : IMarioState
    {
        private Mario mario;
        bool stillJumping = true;
        private bool isSprinting;

        public RightBigJumpingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = true;
            mario.isJumping = true;
            mario.isFalling = false;
            mario.sprite = new RightBigJumpingMarioSprite(mario);
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
        public void Fire()
        {
            mario.State = new RightFireJumpingMarioState(mario);
        }

        public void Star()
        {
            mario.State = new RightBigJumpingMarioState(mario);
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

        public void Idle()
        {

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
            isSprinting = true;
        }
        public void Climb()
        {
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new RightIceJumpingMarioState(mario);
        }
    }
}
