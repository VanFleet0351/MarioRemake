using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.ItemSprites
{
    class GreenMushroomSprite: ISprite
    {
        private Rectangle source = new Rectangle(52, 43, 16, 16);
        private Rectangle destination;
        private IItem item;

        public GreenMushroomSprite(IItem shroom)
        {
            item = shroom;
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
        }
    }
}
