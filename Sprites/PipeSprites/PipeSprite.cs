using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.PipeSprites
{
    class PipeSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(614, 46, 32, 32);
        private int XPosition { get; set; }
        private int YPosition { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }

        public PipeSprite(IPipe pipe)
        {
            XPosition = (int)pipe.Position.X;
            YPosition = (int)pipe.Position.Y;
            SizeX = 64;
            SizeY = 64;
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle(XPosition, YPosition, SizeX, SizeY);
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
