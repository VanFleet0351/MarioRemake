using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    class FireFlowerSprite: ISprite
    {
        private Rectangle destination;
        private int currentFrame = 0;
        private readonly int cycleLength = 45;
        private IItem item;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(52,64,16,16),
            new Rectangle(71,64,16,16),
            new Rectangle(109,64,16,16),
            new Rectangle(90,64,16,16),
        };

        public FireFlowerSprite(IItem flower)
        {
            item = flower;
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet, destination, sources[4 * currentFrame / cycleLength], color);
        }

        public void Update()
        {
            destination = new Rectangle((int)item.Position.X, (int)item.Position.Y, 32, 32);
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
