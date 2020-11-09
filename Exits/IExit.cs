using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Exits
{
    public interface IExit
    {
        //More to be added when mario can finish the level and warp in tunnels
         int LocationX { get; }
         int LocationY { get; }

        void Update();
        void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color);
    }
}
