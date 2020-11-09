using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class MovingGoombaSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private int currentFrame = 0;
        private readonly int cycleLength = 20;
        private readonly IEnemy enemy;
        private readonly List<Rectangle> sources = new List<Rectangle>()
        {
            new Rectangle(187, 894, 16, 16),
            new Rectangle(208, 894, 16, 16)
        };

        public MovingGoombaSprite(IEnemy goomba)
        {
            enemy = goomba;
            LocationX = (int)goomba.Position.X;
            LocationY = (int)goomba.Position.Y;
            SizeX = 32;
            SizeY = 32;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(LocationX, LocationY, SizeX, SizeY);
        }


        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            if (currentFrame < cycleLength / 2)
            {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY, SizeX, SizeY),
                sources[0], color);
            }
            else
            {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY, SizeX, SizeY),
                sources[1], color);
            }
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
        }
    }
}
