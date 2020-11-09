using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Scenery
{
    class Bush3Sprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(85, 253, 64, 16);
        private int positionX { get; set; }
        private int positionY { get; set; }
        private int sizeX = 128;
        private int sizeY = 32;

        public Bush3Sprite(int locationX, int locationY)
        {
            positionX = locationX;
            positionY = locationY;
            destination = new Rectangle(positionX, positionY, sizeX, sizeY);
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