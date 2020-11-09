using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class StarSprite : ISprite
    {
        private Rectangle destination;
        private int currentFrame = 0;
        private readonly int cycleLength = 45;
        private IItem item;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(53,102,14,18),
            new Rectangle(110,102,14,18),
            new Rectangle(72,102,14,18),
            new Rectangle(91,102,14,18)
        };

        public StarSprite(IItem star)
        {
            item = star;
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
            spriteBatch.Draw(spriteSheet, destination, sources[currentFrame * 4 / cycleLength], color);
        }

        public Rectangle ReturnObjectRectangle()
        {
            return destination;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }
    }
}
