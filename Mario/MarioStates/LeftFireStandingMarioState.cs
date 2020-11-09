using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftFireStandingMarioState : IMarioState
    {
        private Mario mario;

        public LeftFireStandingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = false;
            mario.isJumping = false;
            mario.direction = false;
            mario.sprite = new LeftFireStandingMarioSprite(mario);
        }

        public void WalkLeft()
        {
            mario.State = new LeftFireRunningMarioState(mario);
        }

        public void WalkRight()
        {
            mario.State = new RightFireStandingMarioState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftFireJumpingMarioState(mario);
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
            mario.State = new LeftFireCrouchingMarioState(mario);
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
            mario.State = new LeftFireFallingMarioState(mario);
        }

        public void Land()
        {
        }

        public void Sprint()
        {
        }
        public void Climb()
        {
            mario.State = new ClimbingFireMarioState(mario);
        }
        public void Ice()
        {
        }
    }
}
