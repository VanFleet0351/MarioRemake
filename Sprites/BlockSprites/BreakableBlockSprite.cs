using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.ScenerySprites
{
    class BreakableBlockSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }
        private Rectangle destination;
        private Rectangle source = new Rectangle(373, 47, 16, 16);
        private IBlock block;

        public BreakableBlockSprite(IBlock block)
        {
            this.block = block;
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
            sizeX = 32;
            sizeY = 32;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }
        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
            spritebatch.Draw(spritesheet, destination, source, color);
        }

        public void Update()
        {
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
        }
    }
}
