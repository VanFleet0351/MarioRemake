using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Scenery
{
    class CastleSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(272, 218, 80, 80);
        private int positionX { get; set; }
        private int positionY { get; set; }
        private int sizeX = 160;
        private int sizeY = 160;

        public CastleSprite(int locationX, int locationY)
        {
            positionX = locationX;
            positionY = locationY;
            destination = new Rectangle(positionX, positionY, sizeX, sizeY);
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
        }
    }
}