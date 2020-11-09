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
    class Cloud1Sprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(162, 198, 32, 24);
        private int positionX { get; set; }
        private int positionY { get; set; }
        private int sizeX = 64;
        private int sizeY = 48;

        public Cloud1Sprite(int locationX, int locationY)
        {
            positionX = locationX;
            positionY = locationY;
            destination = new Rectangle(positionX, positionY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color,0.0f,new Vector2(0,sizeY/2),SpriteEffects.None,0);
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
