using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.Sprites.MarioSprites;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftBigCrouchingMarioState : IMarioState
    {
        private Mario mario;

        public LeftBigCrouchingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y+20);
            mario.physicsObject.dx = 0;
            mario.physicsObject.runSpeed = 0;
            mario.sprite = new LeftBigCrouchingMarioSprite(mario);
        }

        public void WalkLeft()
        {
        }

        public void WalkRight()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new RightBigCrouchingMarioState(mario);
        }

        public void Jump()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftBigJumpingMarioState(mario);
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

        public void Fire()
        {
            mario.State = new LeftFireCrouchingMarioState(mario);
        }

        public void Star()
        {
        }

        public void Update()
        {
        }

        public void Idle()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftBigStandingMarioState(mario);
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
        }
        public void Climb()
        {
            mario.State = new ClimbingBigMarioState(mario);
        }
        public void Ice()
        {
            mario.State = new LeftIceCrouchingMarioState(mario);
        }
    }
}
