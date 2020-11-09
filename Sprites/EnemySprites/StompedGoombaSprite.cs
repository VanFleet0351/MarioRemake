using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class StompedGoombaSprite : ISprite
    {
        private int XPos { get; set; }
        private int YPos { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private readonly Rectangle sources = new Rectangle(228, 901, 16, 8);
        private float deathCount;

        public StompedGoombaSprite(IEnemy goomba)
        {
            XPos = (int)goomba.Position.X;
            YPos = (int)goomba.Position.Y+8;
            SizeX = 32;
            SizeY = 16;
            deathCount = 1;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            //needed to prevent collisions
            return new Rectangle(0,0,0,0);
        }


        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            if (deathCount <= 1.0f)
            {
                spritebatch.Draw(spritesheet, new Rectangle(XPos, YPos + 8, SizeX, SizeY),
                                    sources, color*deathCount); 
            }
        }

        public void Update()
        {
            deathCount -= 0.025f;
        }
    }
}
