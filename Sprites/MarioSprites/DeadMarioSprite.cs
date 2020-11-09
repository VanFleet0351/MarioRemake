using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Player;

namespace SprintZero.Sprites.MarioSprites
{
    public class DeadMarioSprite : ISprite
    {
        private Mario mario;
        private Rectangle destination;
        private Rectangle source = new Rectangle(45, 509, 15, 14);
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        private readonly int sizeX = 30;
        private readonly int sizeY = 28;

        public DeadMarioSprite(Mario mario)
        {
            this.mario = mario;    
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle((int)mario.Position.X, (int)mario.Position.Y, sizeX, sizeY);
            spritebatch.Draw(spritesheet, destination, source, color);
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return destination;
        }

        public void Update()
        {
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }
    }
}
