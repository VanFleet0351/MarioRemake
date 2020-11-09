using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Iceball;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class IceballSprite : ISprite
    {
        private Rectangle destination;
        private int currentFrame = 0;
        private readonly int cycleLength = 30;
        private IceballObject iceballObject;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(312,944,9,9),
            new Rectangle(323,944,9,9),
            new Rectangle(335,944,9,9),
            new Rectangle(347,944,9,9),
        };

        public IceballSprite(IceballObject iceballObject)
        {
            this.iceballObject = iceballObject;
            destination = new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet, destination, sources[4 * currentFrame / cycleLength], Color.Blue);
        }

        public void Update()
        {
            destination = new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 16, 16);
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }
    }
}
