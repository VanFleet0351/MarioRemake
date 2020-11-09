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
    public class SmallClimbingMarioSprite : ISprite
    {
        private Mario mario;
        private int currentFrame = 0;
        private readonly int cycleLength = 30;
        private Rectangle destination;
        private int sizeX = 32;
        private int sizeY = 32;
        private readonly ArrayList sources = new ArrayList() {
            new Rectangle(23, 527, 14, 16),
            new Rectangle(48, 528, 13, 15)
        };
        public SmallClimbingMarioSprite(Mario mario)
        {
            this.mario = mario;
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
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
