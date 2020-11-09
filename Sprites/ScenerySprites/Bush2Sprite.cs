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
    class Bush2Sprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(151, 253, 48, 16);
        private int positionX { get; set; }
        private int positionY { get; set; }
        private int sizeX = 96;
        private int sizeY = 32;

        public Bush2Sprite(int locationX, int locationY)
        {
            positionX = locationX;
            positionY = locationY;
            destination = new Rectangle(positionX, positionY, sizeX, sizeY);
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