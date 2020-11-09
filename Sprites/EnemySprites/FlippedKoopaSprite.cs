using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Sprites.EnemySprites
{
    class FlippedKoopaSprite : ISprite
    {
        private int LocationX { get; set; }
        private int LocationY { get; set; }
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private readonly IEnemy enemy;
        private readonly Rectangle sources = new Rectangle(540, 824, 16, 14);

        public FlippedKoopaSprite(IEnemy koopa)
        {
            enemy = koopa;
            LocationX = (int)koopa.Position.X;
            LocationY = (int)koopa.Position.Y;
            SizeX = 32;
            SizeY = 28;
        }

        public Rectangle RetrieveSpriteRectangle()
        {
            //needed to prevent collisions
            return new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
                spritebatch.Draw(spritesheet, new Rectangle(LocationX, LocationY+18, SizeX, SizeY),
                        sources, color, 0.0f, new Vector2(0, 0), SpriteEffects.FlipVertically, 1); 
        }

        public void Update()
        {
            LocationX = (int)enemy.Position.X;
            LocationY = (int)enemy.Position.Y;
        }
    }
}