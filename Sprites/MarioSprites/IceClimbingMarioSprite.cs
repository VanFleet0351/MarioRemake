using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Player;

namespace SprintZero.Sprites.MarioSprites
{
    class IceClimbingMarioSprite : ISprite
    {
        private Mario mario;
        private int currentFrame = 0;
        private readonly int cycleLength = 30;
        private Rectangle destination;
        private readonly ArrayList sources = new ArrayList() {
            new Rectangle(94, 609, 14, 16),
            new Rectangle(119, 610, 13, 15)
        };
        public IceClimbingMarioSprite(Mario mario)
        {
            this.mario = mario;
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, 32, 48);
            spritebatch.Draw(spritesheet, destination, (Rectangle)sources[currentFrame / (cycleLength / 2)], Color.Blue);
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
