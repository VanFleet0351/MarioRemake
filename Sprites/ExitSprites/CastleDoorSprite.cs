using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Sprites.ExitSprites
{
    public class CastleDoorSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(315, 300, 37, 48);
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private readonly int sizeX = 74;
        private readonly int sizeY = 96;

        public CastleDoorSprite(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, source, color);
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
