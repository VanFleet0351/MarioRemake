using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftBigRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public LeftBigRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.sprite = new LeftBigRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.physicsObject.Accelerate();
        }

        public void WalkRight()
        {
            mario.State = new LeftBigStandingMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftBigJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.State = new LeftSmallStandingMarioState(mario);
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
            mario.State = new LeftBigCrouchingMarioState(mario);
        }

        public void Fire()
        {
            mario.State = new LeftFireRunningMarioState(mario);
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
        }

        public void Idle()
        {
            mario.State = new LeftBigSlidingMarioState(mario);
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
            mario.State = new LeftIceRunningMarioState(mario);
        }
    }
}
