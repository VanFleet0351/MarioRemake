using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.ScenerySprites
{
    class ItemBlockEmptySprite : ISprite
    {
        private Rectangle destination;
        private Rectangle source = new Rectangle(373, 84, 16, 16);
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private readonly IBlock block;

        public ItemBlockEmptySprite(IBlock block)
        {
            this.block = block;
            LocationX = (int)block.Position.X;
            LocationY = (int)block.Position.Y;

        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            destination = new Rectangle(LocationX, LocationY, 32, 32);
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
