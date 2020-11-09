using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Sprites.ScenerySprites
{
    public class FlagPoleSprite : ISprite
    {
        private Rectangle destinationPole;
        private Rectangle destinationBall;
        private Rectangle Pole = new Rectangle(275, 54, 2, 144);
        private Rectangle Ball = new Rectangle(272, 46, 8, 8);

        public FlagPoleSprite(int locationX, int locationY)
        {
            destinationPole = new Rectangle(locationX, locationY, 4, 288);
            destinationBall = new Rectangle(locationX - 6, locationY - 16, 16, 16);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destinationPole, Pole, color);
            spritebatch.Draw(spritesheet, destinationBall, Ball, color);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destinationPole;
        }

        public void Update()
        {
            //no update, only one sprite
        }
    }
}

