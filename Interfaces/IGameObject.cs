using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Interfaces
{
    public interface IGameObject: IHittable
    {
        Vector2 Position { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color);
        void SideCollisionResponse();
    }
}
