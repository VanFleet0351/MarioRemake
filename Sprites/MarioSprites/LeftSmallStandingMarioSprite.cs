using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Player;

namespace SprintZero.Sprites.MarioSprites
{
    public class LeftSmallStandingMarioSprite : ISprite
    {
        private Mario mario;
        private Rectangle destination;
        private Rectangle source = new Rectangle(23, 507, 13, 16);
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        private readonly int sizeX = 26;
        private readonly int sizeY = 32;
        public LeftSmallStandingMarioSprite(Mario mario)
        {
            this.mario = mario;
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
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
