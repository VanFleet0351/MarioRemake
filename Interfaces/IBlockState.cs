using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Interfaces
{
    public interface IBlockState
    {
        ISprite sprite { get; set; }
        IBlock block {get; set;}
        bool WasHit { get; set; }
        void BeHit();
        void BeBumped();
        void Update();
        void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color);

        Rectangle ReturnObjectRectangle();
    }
}
