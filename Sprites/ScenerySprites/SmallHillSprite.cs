using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Scenery
{
    class SmallHillSprite : ISprite
    {
        private Rectangle source = new Rectangle(48, 176, 50, 20);
        private Rectangle destination;
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        private int sizeX = 96;
        private int sizeY = 38;

        public SmallHillSprite(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color, 0.0f, new Vector2(0, sizeY/2), SpriteEffects.None, 0);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
        }
    }
}