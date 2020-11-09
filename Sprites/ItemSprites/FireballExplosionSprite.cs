using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Fireball;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class FireballExplosionSprite: ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength = 15;
        private FireballExpolsion fireballObject;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(360,946,8,8),
            new Rectangle(372,943,12,14),
            new Rectangle(388,942,16,16),
        };
        private readonly List<Rectangle> destinations = new List<Rectangle>();
    

        public FireballExplosionSprite(FireballExpolsion fireballObject)
        {
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 16, 16));
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 24, 28));
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 32, 32));
            this.fireballObject = fireballObject;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet,destinations[3*currentFrame/cycleLength] , sources[3 * currentFrame / cycleLength], color);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
            destinations.Clear();
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 16, 16));
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 24, 28));
            destinations.Add(new Rectangle((int)fireballObject.Position.X, (int)fireballObject.Position.Y, 32, 32));
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            //to avoid collisions
            return new Rectangle(0,0,0,0);
        }
    }
}
