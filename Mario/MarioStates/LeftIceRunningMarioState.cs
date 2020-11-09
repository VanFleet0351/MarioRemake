using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftIceRunningMarioState : IMarioState
    {
        private Mario mario;
        private bool isSprinting;

        public LeftIceRunningMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.IceMario = true;
            mario.sprite = new LeftIceRunningMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.physicsObject.Accelerate();
        }

        public void WalkRight()
        {
            mario.State = new LeftIceStandingMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftIceJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 32);
            mario.IceMario = false;
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
            mario.State = new LeftIceCrouchingMarioState(mario);
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
            mario.State = new LeftIceSlidingMarioState(mario);
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
