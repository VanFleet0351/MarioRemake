using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.ScenerySprites
{
    class ItemBlockSprite : ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength = 60;
        private Rectangle destination;
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private ArrayList sources = new ArrayList() {
            new Rectangle(372,160,16,16),
            new Rectangle(390,160,16,16),
            new Rectangle(408,160,16,16)
        };
        private IBlock block;

        public ItemBlockSprite(IBlock block)
        {
            this.block = block;
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            destination = new Rectangle(LocationX, LocationY, 32, 32);
            if (currentFrame < cycleLength / 6)
            {
                spriteBatch.Draw(spriteSheet, destination,
                (Rectangle)sources[0], color);
            }
            else if (currentFrame >= cycleLength / 6 && currentFrame < cycleLength / 3)
            {
                spriteBatch.Draw(spriteSheet, destination,
                (Rectangle)sources[1], color);
            }
            else if (currentFrame >= cycleLength / 3 && currentFrame < (cycleLength * 2) / 3)
            {
                spriteBatch.Draw(spriteSheet, destination,
                (Rectangle)sources[2], color);
            }
            else if (currentFrame >= (cycleLength * 2) / 3 && currentFrame < (cycleLength * 5) / 6)
            {
                spriteBatch.Draw(spriteSheet, destination,
                (Rectangle)sources[1], color);
            }
            else
            {
                spriteBatch.Draw(spriteSheet, destination,
                (Rectangle)sources[0], color);
            }
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;
        }
    }
}