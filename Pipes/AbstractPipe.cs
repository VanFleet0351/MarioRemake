using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Pipes
{
    public abstract class AbstractPipe : IPipe
    {
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }

        protected AbstractPipe(int locationX, int locationY)
        {
            Position = new Vector2(locationX, locationY);
        }

        public Rectangle GetHitBox()
        {
            return Sprite.RetrieveSpriteRectangle();
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            Sprite.Draw(spriteBatch, spriteSheet, color);
        }
        public void SideCollisionResponse()
        {

        }
    }
}
