using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System;

namespace SprintZero.Sprites.ScenerySprites
{
    class BrokenBlockSprite: ISprite
    {
        private Rectangle destinationTopLeft;
        private Rectangle destinationBottomLeft;
        private Rectangle destinationTopRight;
        private Rectangle destinationBottomRight;
        private Rectangle source = new Rectangle(432, 47, 8, 8);
        private int locationXLeft;
        private int locationXRight;
        private int locationYHigh;
        private int locationYLow;
        private int sizeX;
        private int sizeY;
        private int maxHeight;
        private Boolean goingUp = true;
        private float rotation;
        private Vector2 origin;

        public BrokenBlockSprite(IBlock block)
        {
            maxHeight = (int)block.Position.Y-30;
            sizeX = 16;
            sizeY = 16;
            locationXLeft = (int)block.Position.X;
            locationXRight = (int)block.Position.X;
            locationYHigh = (int)block.Position.Y;
            locationYLow = (int)block.Position.Y + 5;
            destinationTopLeft = new Rectangle(locationXLeft, locationYHigh, sizeX, sizeY);
            destinationBottomLeft = new Rectangle(locationXLeft, locationYHigh, sizeX, sizeY);
            destinationTopRight = new Rectangle(locationXRight, locationYHigh, sizeX, sizeY);
            destinationBottomRight = new Rectangle(locationXRight, locationYHigh, sizeX, sizeY);
            rotation = 0.0f;
            origin = new Vector2(sizeX / 4, sizeY / 4);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destinationTopLeft, source, color, rotation, origin, SpriteEffects.None, 0.0f);
            spritebatch.Draw(spritesheet, destinationBottomLeft, source, color, rotation, origin, SpriteEffects.None, 0.0f);
            spritebatch.Draw(spritesheet, destinationTopRight, source, color, rotation, origin, SpriteEffects.None, 0.0f);
            spritebatch.Draw(spritesheet, destinationBottomRight, source, color, rotation, origin, SpriteEffects.None, 0.0f);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            if (goingUp)
            {
                return destinationTopLeft;
            }
            else
            {
                return new Rectangle(0,0,0,0);
            }

        }

        public void Update()
        {
            if (goingUp)
            {
                if(locationYHigh > maxHeight)
                {
                    locationYHigh -= 3;
                    locationYLow -= 1;
                    locationXRight += 3;
                    locationXLeft -= 3;
                }
                else
                {
                    goingUp = false;
                }
            }else if(locationYHigh < 750)
            {
                locationYHigh += 4;
                locationYLow += 4;
            }
            rotation += 0.1f;
            destinationTopLeft = new Rectangle(locationXLeft, locationYHigh, sizeX, sizeY);
            destinationBottomLeft = new Rectangle(locationXLeft, locationYLow, sizeX, sizeY);
            destinationTopRight = new Rectangle(locationXRight, locationYHigh, sizeX, sizeY);
            destinationBottomRight = new Rectangle(locationXRight, locationYLow, sizeX, sizeY);
        }
    }
}
