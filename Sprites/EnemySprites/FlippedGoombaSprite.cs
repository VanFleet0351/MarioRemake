using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class FlippedGoombaSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private IEnemy enemy;
        private readonly Rectangle sources = new Rectangle(187, 894, 16, 16);

        public FlippedGoombaSprite(IEnemy koopa)
        {
            enemy = koopa;
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
            SizeX = 32;
            SizeY = 32;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            //needed to prevent collisions
            return new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY, SizeX, SizeY),
                 sources, color, 0.0f, new Vector2(SizeX/4, SizeY/4), SpriteEffects.FlipVertically, 1);
        }

        public void Update()
        {
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
        }

    }
}
