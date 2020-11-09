using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.ScenerySprites
{
    class UnbreakableBlockSprite : ISprite
    {
        private int xPos { get; set; }
        private int yPos { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }
        private Rectangle destination;
        private Rectangle source = new Rectangle(373, 142, 16, 16);
        public UnbreakableBlockSprite(IBlock block)
        {
            xPos = (int)block.Position.X;
            yPos = (int)block.Position.Y;
            sizeX = 32;
            sizeY = 32;
            destination = new Rectangle(xPos, yPos, sizeX, sizeY);
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
            //no update, only one sprite
        }
    }
}
