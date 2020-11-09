using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
namespace SprintZero.Sprites.ScenerySprites
{
    class GroundBlockSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int sizeX { get; set; }
        private int sizeY { get; set; }
        private Rectangle destination;
        private Rectangle source = new Rectangle(373, 124, 16, 16);
        private IBlock block;
        public GroundBlockSprite(IBlock block)
        {
            this.block = block;
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
            sizeX = 32;
            sizeY = 32;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
        }
        public GroundBlockSprite(int x, int y)
        {
            LocationX = x;
            LocationY = y;
            sizeX = 32;
            sizeY = 32;
            destination = new Rectangle(LocationX, LocationY, sizeX, sizeY);
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
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;
        }
    }
}
