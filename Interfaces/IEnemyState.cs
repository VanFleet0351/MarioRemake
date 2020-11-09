using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Interfaces
{
    public interface IEnemyState: IHittable
    {
        ISprite Sprite { get; set; }

        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update();
        void HitFromLeft(IGameObject hittingObject);
        void HitFromRight(IGameObject hittingObject);
        void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color);
    }
}
