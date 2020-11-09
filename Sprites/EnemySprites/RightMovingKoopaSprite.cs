using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class RightMovingKoopaSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private int currentFrame = 0;
        private readonly int cycleLength = 60;
        private IEnemy enemy;
        private readonly List<Rectangle> sources = new List<Rectangle>()
        {
            new Rectangle(481, 816,16, 23),
            new Rectangle(451, 816, 16, 24)
        };
        public SpriteEffects effect = SpriteEffects.FlipHorizontally;

        public RightMovingKoopaSprite(IEnemy koopa)
        {
            enemy = koopa;
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
            SizeX = 32;
            SizeY = 46;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(LocationX, LocationY+5, SizeX, SizeY-5);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            if (currentFrame < cycleLength / 2)
            {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY, SizeX, SizeY),
                sources[0], color, 0.0f, new Vector2(0, 0), effect, 1);
            }
            else
            {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY - 1, SizeX, SizeY),
                sources[1], color, 0.0f, new Vector2(0, 0), effect, 1);
            }
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
        }
    }
}

