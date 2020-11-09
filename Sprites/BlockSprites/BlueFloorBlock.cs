using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.BlockSprites
{
    public class BlueFloorBlock: ISprite
    {
        private Rectangle SourceSprite = new Rectangle(393, 124, 16, 16);
        private Rectangle destination;

        public BlueFloorBlock(IBlock block)
        {
            destination = new Rectangle((int)block.Position.X, (int)block.Position.Y, 32, 32);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, destination, SourceSprite, color);
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
