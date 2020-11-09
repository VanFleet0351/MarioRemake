
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class StompedKoopaSprite : ISprite
    {
        private int xPos { get; set; }
        private int yPos { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }
        private bool regen = false;
        private int currentFrame = 0;
        private int regenTimer = 0;
        private IEnemy enemy;
        private readonly int regenLength = 300;
        private readonly int cycleLength = 60;
        private readonly int squishFactor = 18;
        private readonly List<Rectangle> sources = new List<Rectangle>()
        {
            new Rectangle(540,825,16,14),
            new Rectangle(510,824,16,15)
        };

        public StompedKoopaSprite(IEnemy koopa)
        {
            enemy = koopa;
            xPos = (int)koopa.Position.X;
            yPos = (int)koopa.Position.Y;
            sizeX = 32;
            sizeY = 28;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(xPos, yPos+18, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            if (regen && (currentFrame > cycleLength / 2))
            {
                spritebatch.Draw(spritesheet, new Rectangle(xPos, yPos+squishFactor, sizeX, sizeY),
                (Rectangle)sources[1], color);
            }
            else
            {
                spritebatch.Draw(spritesheet, new Rectangle(xPos, yPos+squishFactor, sizeX, sizeY),
                (Rectangle)sources[0], color);
            }
        }

        public void Update()
        {
            currentFrame++;
            regenTimer++;
            if (currentFrame == cycleLength)
            {
                currentFrame = 0;
            }
            if(regenTimer == regenLength)
            {
                regen = true;
            }
            xPos = (int)enemy.Position.X;
            yPos = (int)enemy.Position.Y;
        }
    }
}