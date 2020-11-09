using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.FlagPoles.BlockStates
{
    public abstract class AbstractBlockState : IBlockState
    {
        public ISprite sprite { get; set; }
        public IBlock block { get; set; }
        public bool WasHit { get; set; }
        private int hitHeight = 0;

        protected AbstractBlockState(IBlock block)
        {
            WasHit = false;
            this.block = block;
        }

        public virtual void BeHit()
        {
        }
        
        public virtual void BeBumped()
        {
            BeHit();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle ReturnObjectRectangle()
        {
            return sprite.RetrieveSpriteRectangle();
        }

        public virtual void Update()
        {
            if (WasHit && hitHeight < 5)
            {
                hitHeight++;
                block.Position = new Vector2(block.Position.X, block.Position.Y - 1);
            }
            else if (hitHeight > 0)
            {
                WasHit = false;
                hitHeight--;
                block.Position = new Vector2(block.Position.X, block.Position.Y + 1);
            }
            sprite.Update();
        }
    }
}
