using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.PipeSprites
{
    class PipeExtensionSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(616, 82, 28, 16);
        private int XPosition { get; set; }
        private int YPosition { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private int numberOfExtensions;

        public PipeExtensionSprite(IPipe pipe, int size)
        {
            XPosition = (int)pipe.Position.X;
            YPosition = (int)pipe.Position.Y;
            SizeX = 56;
            SizeY = 32;
            numberOfExtensions = size;
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle(XPosition, YPosition, SizeX, SizeY*numberOfExtensions);
            spritebatch.Draw(spritesheet, destination, source, color, 0.0f, new Vector2(0, 0), SpriteEffects.None, 1);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(0,0,0,0);
        }

        public void Update()
        {
        }
    }
}
