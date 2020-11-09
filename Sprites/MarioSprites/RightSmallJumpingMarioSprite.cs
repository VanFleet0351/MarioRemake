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
    public class RightSmallJumpingMarioSprite : ISprite
    {
        private Mario mario;
        private Rectangle destination;
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        private readonly int sizeX = 32;
        private readonly int sizeY = 32;
        private Rectangle source = new Rectangle(140, 507, 16, 16);
        public RightSmallJumpingMarioSprite(Mario mario)
        {
            this.mario = mario;
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
            spritebatch.Draw(spritesheet, destination, source, color);
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
