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
    class Cloud2Sprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(46, 198, 48, 24);
        private int positionX { get; set; }
        private int positionY { get; set; }
        private int sizeX = 98;
        private int sizeY = 44;

        public Cloud2Sprite(int locationX, int locationY)
        {
            positionX = locationX;
            positionY = locationY;
            destination = new Rectangle(positionX, positionY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color, 0, new Vector2(0,sizeY/2), SpriteEffects.None, 0);
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