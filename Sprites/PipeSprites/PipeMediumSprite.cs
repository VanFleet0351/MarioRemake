using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.PipeSprites
{
    class PipeMediumSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle destination2;
        private Rectangle source = new Rectangle(614, 46, 32, 32);
        private Rectangle source2 = new Rectangle(616, 82, 28, 16);
        private int XPosition { get; set; }
        private int YPosition { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }

        public PipeMediumSprite(IPipe pipe)
        {
            XPosition = (int)pipe.Position.X;
            YPosition = (int)pipe.Position.Y;
            SizeX = 64;
            SizeY = 64;
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle(XPosition, YPosition, SizeX, SizeY);
            destination2 = new Rectangle(XPosition+4, YPosition+64, 56, 32);
            spritebatch.Draw(spritesheet, destination, source, color);
            spritebatch.Draw(spritesheet, destination2, source2, color);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return Rectangle.Union(destination, destination2);
        }

        public void Update()
        {
        }
    }
}
