using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.BlocksRefactored.ObstacleHitBox
{
    public class ObstacleCombinedHitBox : IBlock
    {
        public Vector2 Position { get; set; }
        public IBlockState State { get; set; }
        public bool WasHit { get; set; }

        private Rectangle Box;

        public ObstacleCombinedHitBox(int locationX, int locationY, int width, int height)
        {
            Position = new Vector2(locationX, locationY);
            Box = new Rectangle(locationX, locationY, width, height);
            WasHit = false;
        }

        public void SideCollisionResponse()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
        }

        public Rectangle GetHitBox()
        {
            return Box;
        }

        public void Update()
        {
        }

        public void BeHit()
        {
        }

        public void BeBumped()
        {
        }
    }
}
