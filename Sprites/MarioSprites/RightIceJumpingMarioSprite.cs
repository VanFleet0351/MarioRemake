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
    class RightIceJumpingMarioSprite : ISprite
    {
        private Rectangle destination;
 
        public int sizeX = 32;
        public int sizeY = 64;
        private Rectangle source = new Rectangle(238, 628, 16, 32);
        private Mario mario;

        public RightIceJumpingMarioSprite(Mario mario)
        {
            this.mario = mario;
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
        }


        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, Color.Blue);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
        }
    }
}
