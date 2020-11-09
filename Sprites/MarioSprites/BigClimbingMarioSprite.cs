using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Player;

namespace SprintZero.Sprites.MarioSprites
{
   public class BigClimbingMarioSprite : ISprite
    {
        private Mario mario;
        private int currentFrame = 0;
        private readonly int cycleLength = 30;
        private Rectangle destination;
        private readonly ArrayList sources = new ArrayList() {
            new Rectangle(23, 527, 14, 16),
            new Rectangle(48, 528, 13, 15)
        };
        public BigClimbingMarioSprite(Mario mario)
        {
            this.mario = mario;
            
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, 32, 48);
            spritebatch.Draw(spritesheet, destination, (Rectangle)sources[currentFrame / (cycleLength / 2)], color);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            currentFrame++;
            if(currentFrame == cycleLength)
                currentFrame = 0;
        }

    }
}
