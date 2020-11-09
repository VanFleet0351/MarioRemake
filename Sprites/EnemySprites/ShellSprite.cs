using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    public class ShellSprite: ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private IEnemy enemy;
        private readonly Rectangle sources = new Rectangle(540, 825, 16, 14);
        private readonly int squishFactor;

        public ShellSprite(IEnemy koopa)
        {
            squishFactor = 18;
            enemy = koopa;
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
            SizeX = 32;
            SizeY = 28;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            return new Rectangle(LocationX, LocationY + 18, SizeX, SizeY);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY + squishFactor, SizeX, SizeY),
                sources, color);

        }

        public void Update()
        {
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
        }
    }
}
