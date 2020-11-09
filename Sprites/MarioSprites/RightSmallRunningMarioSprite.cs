﻿using System;
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
    class RightSmallRunningMarioSprite : ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength = 60;
        private Mario mario;
        private Rectangle destination;
  
        public int sizeX = 32;
        public int sizeY = 32;
        private ArrayList sources = new ArrayList() {
            new Rectangle(85, 507, 12, 16),
            new Rectangle(100, 508, 14, 15),
            new Rectangle(117, 507, 16, 16)
        };

        public RightSmallRunningMarioSprite(Mario mario)
        {
            this.mario = mario;
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            if (currentFrame > cycleLength / 4 && currentFrame <= cycleLength / 2)
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[1], color);
            }
            else if (currentFrame >= (3 * cycleLength) / 4)
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[2], color);
            }
            else
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[0], color);
            }
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
        }
    }
}
