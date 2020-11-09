using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System.Collections.Generic;

namespace SprintZero.Sprites.ItemSprites
{
    public class SpinningCoinSprite: ISprite
    {
        private readonly List<Rectangle> coinSource = new List<Rectangle>()
        {
            new Rectangle(434,145,1,14),
            new Rectangle(440,145,4,14),
            new Rectangle(448,145,8,14),
            new Rectangle(461,145,4,14)
        };
        private int currentFrame = 0;
        private int spinCount = 0;
        private int cycleLength = 40;
        private int coinLocation;
        private bool spinOver = false;
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private IItem item;

        public SpinningCoinSprite(IItem SpinningCoin)
        {
            item = SpinningCoin;
            LocationX = (int)item.Position.X; 
            LocationY = (int)item.Position.Y;
            coinLocation = LocationY;
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            if (!spinOver)
            {
                if (currentFrame < 10)
                {
                    spritebatch.Draw(spritesheet, new Vector2(LocationX + 16, coinLocation), coinSource[0], Color.White, 0.0f, new Vector2(0, 14), 2.0f, SpriteEffects.None, 0.0f);
                }
                else if (currentFrame >= 10 && currentFrame < 20)
                {
                    spritebatch.Draw(spritesheet, new Vector2(LocationX + 16, coinLocation), coinSource[1], Color.White, 0.0f, new Vector2(2, 14), 2.0f, SpriteEffects.None, 0.0f);
                }
                else if (currentFrame >= 20 && currentFrame < 30)
                {
                    spritebatch.Draw(spritesheet, new Vector2(LocationX + 16, coinLocation), coinSource[2], Color.White, 0.0f, new Vector2(4, 14), 2.0f, SpriteEffects.None, 0.0f);
                }
                else
                {
                    spritebatch.Draw(spritesheet, new Vector2(LocationX + 16, coinLocation), coinSource[3], Color.White, 0.0f, new Vector2(2, 14), 2.0f, SpriteEffects.None, 0.0f);
                }
            }
        }

        public void Update()
        {
            LocationX = (int)item.Position.X;
            LocationY = (int)item.Position.Y;
            currentFrame++;
            spinCount++;
            if (currentFrame > cycleLength)
            {
                currentFrame = 0;
            }
            if (spinCount < 20)
            {
                coinLocation -= 2;
            }
            else if (spinCount < 40)
            {
                coinLocation += 2;
            }
            else
            {
                spinOver = true;
            }
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(0,0,0,0);
        }
    }
}
