using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Enemies;
using SprintZero.Interfaces;


namespace SprintZero.Items
{
    public abstract class AbstractItem : IItem
    {
        public Vector2 Position { get; set; }
        public bool IsFalling { get; set; }
        protected ISprite Sprite { get; set; }
        public IItemPhysicsObject physicsObject { get; set; }

        protected int locationMod { get; set; }

        protected AbstractItem(Vector2 position)
        {
            Position = position;
            locationMod = 0;
            physicsObject = new ItemPhysicsObject(this);
        }

        public virtual void BeCollected()
        {
            Game1.Instance.currentState.Level.RemoveFromLevel(this);
        }

        public virtual void SideCollisionResponse()
        {
            locationMod *= -1;
        }


        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            Sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle GetHitBox()
        {
            return Sprite.RetrieveSpriteRectangle();
        }

        public virtual void Update()
        {
            Position = new Vector2(Position.X + locationMod, Position.Y);
            Sprite.Update();

            if (IsFalling)
                Fall();
            else
                physicsObject.Reset(true);
        }

        public void Fall()
        {
            physicsObject.Fall();
        }
    }
}
