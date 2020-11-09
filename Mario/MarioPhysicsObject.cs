using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.ScreenCamera;
using System;

namespace SprintZero.MarioStatePattern
{
    class MarioPhysicsObject : IMarioPhysicsObject
    {
        public IMario mario { get; set; }
        public float gravity { get; set; }
        public float aerialSpeed { get; set; }
        public float maxFallSpeed { get; set; }
        public float runAcceleration { get; set; }
        public float runSpeed { get; set; }
        public float maxRunSpeed { get; set; }
        public float maxSprintSpeed { get; set; }
        public float decay { get; set; }
        public float dx { get; set; }
        public float dy { get; set; }
        public float dt { get; set; }
        public int jumptick { get; set; }

        public MarioPhysicsObject(IMario mario)
        {
            this.mario = mario;
            gravity = -1.8F;
            aerialSpeed = 25.0F;
            maxFallSpeed = 6.0F;
            runAcceleration = 0.4F;
            runSpeed = 0;
            maxRunSpeed = 7.0F;
            maxSprintSpeed = 10.0F;
            decay = 1F;
            dx = 0;
            dy = 0;
            dt = 0.5F;
        }

        public void Fall()
        {
            if (aerialSpeed <= maxFallSpeed)
                aerialSpeed = aerialSpeed + (gravity * dt);
            else
                aerialSpeed = maxFallSpeed;

            dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);

            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - dy);
        }

        public void Jump()
        {
            jumptick++;

            dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);
            aerialSpeed = aerialSpeed + (gravity * dt);
            
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - dy);
        }

        public void SlowDownInAir()
        {
            runSpeed = runSpeed - (runAcceleration * dt);
            if (runSpeed < -2.0F)
                runSpeed = -2.0F;
        }

        public void Accelerate()
        {
            if (runSpeed < maxRunSpeed)
                runSpeed = runSpeed + (runAcceleration * dt);
            else
                runSpeed = maxRunSpeed;
        }

        public void Run(bool direction)
        {
            maxRunSpeed = 7.0F;
            dx = (runSpeed * dt) + (0.5F * runAcceleration * dt * dt);

            if (!direction)
                dx = -dx;

            mario.Position = new Vector2(mario.Position.X + dx, mario.Position.Y);
        }

        public void Sprint(bool direction)
        {
            maxRunSpeed = maxSprintSpeed;
            dx = (runSpeed * dt) + (0.5F * runAcceleration * dt * dt);

            if (!direction)
                dx = -dx;

            mario.Position = new Vector2(mario.Position.X + dx, mario.Position.Y);
        }

        public void MaintainMomentum(bool direction)
        {
            if (runSpeed > 5.5F)
            {
                runSpeed = runSpeed - (decay * runAcceleration * dt);
                dx = (runSpeed * dt) + (0.5F * runAcceleration * dt * dt);

                if (!direction)
                    dx = -dx;

                if (mario.Position.X + dx <= PlayerOneCamera.Instance.LeftBound)
                {
                    mario.Position = new Vector2(PlayerOneCamera.Instance.LeftBound + 1, mario.Position.Y);
                }
                else
                {
                    mario.Position = new Vector2(mario.Position.X + dx, mario.Position.Y);
                }
            } else
            {
                ResetX();
            }
        }

        public void ResetX()
        {
            runAcceleration = 0.4F;
            dx = 0;
            runSpeed = 0;
            maxRunSpeed = 7.0F;
        }

        public void ResetY()
        {
            aerialSpeed = 25.0F;
            jumptick = 0;
            dy = 0;
        }
    }
}
