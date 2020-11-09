using SprintZero.Interfaces;
using SprintZero.Player;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Sprites.MarioSprites;
using SprintZero.Decorator;

namespace SprintZero.MarioStatePattern.MarioStates
{
    class LeftIceCrouchingMarioState : IMarioState
    {
        private Mario mario;

        public LeftIceCrouchingMarioState(Mario mario)
        {
            this.mario = mario;
            mario.direction = false;
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 20);
            mario.physicsObject.dx = 0;
            mario.physicsObject.runSpeed = 0;
            mario.IceMario = true;
            mario.sprite = new LeftIceCrouchingMarioSprite(mario);
        }

        public void WalkLeft()
        {
        }

        public void WalkRight()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new RightIceCrouchingMarioState(mario);
        }

        public void Jump()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftIceJumpingMarioState(mario);
        }

        public void GetHit()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 12);
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
            mario.State = new LeftIceCrouchingMarioState(mario);
        }
        public void Idle()
        {

            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 20);
            mario.State = new LeftIceStandingMarioState(mario);
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
