using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.FlagPoles;

namespace SprintZero.Sprites.ScenerySprites
{
    public class FlagSprite: ISprite
    {
        private Rectangle source = new Rectangle(432, 84, 16, 16);
        private Rectangle destination;
        private FlagPole FlagPole;

        public FlagSprite(FlagPole flagPole)
        {
            FlagPole = flagPole;
            destination = new Rectangle((int)FlagPole.Position.X+32, (int)FlagPole.Position.Y, 32, 32);
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
            destination = new Rectangle((int)FlagPole.Position.X-32, (int)FlagPole.Position.Y, 32, 32);
        }
    }
}
