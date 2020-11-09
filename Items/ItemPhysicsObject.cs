using SprintZero.Interfaces;

namespace SprintZero.Enemies
{
    public class ItemPhysicsObject : IItemPhysicsObject
    {
        public IMario mario { get; set; }
        public IItem Item { get; set; }
        public float gravity { get; set; }
        public float aerialSpeed { get; set; }
        public float maxFallSpeed { get; set; }
        public float runAcceleration { get; set; }
        public float runSpeed { get; set; }
        public float maxRunSpeed { get; set; }
        public float Decay { get; set; }
        public float dx { get; set; }
        public float dy { get; set; }
        public float dt { get; set; }
        public int jumptick { get; set; }

        public ItemPhysicsObject(IItem item)
        {
            Item = item;
            gravity = -1.8F;
            aerialSpeed = 0;
            maxFallSpeed = 7.0F;
            dt = 0.5F;
            dy = 0;
        }

        public void Fall()
        {
            if (aerialSpeed <= maxFallSpeed)
            {
                dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);
                aerialSpeed = aerialSpeed + (gravity * dt);
            }
            else
            {
                aerialSpeed = maxFallSpeed;
                dy = (aerialSpeed * dt) + (0.5F * gravity * dt * dt);
            }
            Item.Position = new Microsoft.Xna.Framework.Vector2(Item.Position.X, Item.Position.Y - dy);
        }

        public void Jump()
        {
        }

        public void Reset(bool direction)
        {
            aerialSpeed = 0;
            dy = 0;
        }

        public void Running(bool direction)
        {
        }

        public void Update()
        {
        }

        public void SlowDownInAir(bool direction)
        {
        }
    }
}
