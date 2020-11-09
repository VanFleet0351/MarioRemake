using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    class CoinSprite: ISprite
    {
        private Rectangle destination;
        private int currentFrame = 0;
        private readonly int cycleLength = 45;
        private IItem item;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(427,179,10,14),
            new Rectangle(439,179,10,14),
            new Rectangle(451,179,10,14)
        };

        public CoinSprite(IItem coin)
        {
            item = coin;
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 20, 28);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet, destination, sources[3 * currentFrame / cycleLength], color);
        }

        public void Update()
        {
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 20, 28);
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
