using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Fireball;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class FireballSprite : ISprite
    {
        private Rectangle destination;
        private int currentFrame = 0;
        private readonly int cycleLength = 30;
        private FireballObject fireballObject;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(312,944,9,9),
            new Rectangle(323,944,9,9),
            new Rectangle(335,944,9,9),
            new Rectangle(347,944,9,9),
        };

        public FireballSprite(FireballObject fireballObject)
        {
            this.fireballObject = fireballObject;
            destination = new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet, destination, sources[4 * currentFrame / cycleLength], color);
        }

        public void Update()
        {
            destination = new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 16, 16);
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
