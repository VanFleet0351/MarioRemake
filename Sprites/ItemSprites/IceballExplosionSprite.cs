using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Fireball;
using SprintZero.Iceball;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class IceballExplosionSprite: ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength = 15;
        private IceballExplosion iceballObject;
        private readonly List<Rectangle> sources = new List<Rectangle>
        {
            new Rectangle(360,946,8,8),
            new Rectangle(372,943,12,14),
            new Rectangle(388,942,16,16),
        };
        private readonly List<Rectangle> destinations = new List<Rectangle>();
    

        public IceballExplosionSprite(IceballExplosion iceballObject)
        {
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 16, 16));
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 24, 28));
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 32, 32));
            this.iceballObject = iceballObject;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            spriteBatch.Draw(spriteSheet,destinations[3*currentFrame/cycleLength] , sources[3 * currentFrame / cycleLength], Color.Blue);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
            destinations.Clear();
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 16, 16));
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 24, 28));
            destinations.Add(new Rectangle((int)iceballObject.Position.X, (int)iceballObject.Position.Y, 32, 32));
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            //to avoid collisions
            return new Rectangle(0,0,0,0);
        }
    }
}
