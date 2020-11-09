using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftIceStandingMarioState : IMarioState
    {
        private Mario mario;

        public LeftIceStandingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = false;
            mario.IceMario = true;
            mario.sprite = new LeftIceStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftIceRunningMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightIceStandingMarioState(mario);
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
            mario.physicsObject.ResetX();
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
