using SprintZero.Interfaces;
using SprintZero.Player;
using Microsoft.Xna.Framework;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftFireCrouchingMarioState : IMarioState
    {
        private Mario mario;

        public LeftFireCrouchingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 20);
            mario.physicsObject.dx = 0;
            mario.physicsObject.runSpeed = 0;
            mario.sprite = new LeftFireCrouchingMarioSprite(mario);
        }

        public void WalkLeft()
        {
        }

        public void WalkRight()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new RightFireCrouchingMarioState(mario);
        }

        public void Jump()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftFireJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 12);
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
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftFireStandingMarioState(mario);
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
