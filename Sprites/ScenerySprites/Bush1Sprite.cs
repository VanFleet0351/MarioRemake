using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Scenery
{
    class Bush1Sprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(51, 253, 32, 16);
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        private int sizeX = 64;
        private int sizeY = 32;

        public Bush1Sprite(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color, 0.0f, new Vector2(0, sizeY/2), SpriteEffects.None, 0);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
        }
    }
}