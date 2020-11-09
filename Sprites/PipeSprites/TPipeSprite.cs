using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.PipeSprites
{
    class TPipeSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(610, 102, 34, 32);
        private int XPosition { get; set; }
        private int YPosition { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }

        public TPipeSprite(IPipe pipe)
        {
            XPosition = (int)pipe.Position.X;
            YPosition = (int)pipe.Position.Y;
            SizeX = 68;
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
