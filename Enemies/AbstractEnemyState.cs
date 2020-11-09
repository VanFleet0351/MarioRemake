using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.Enemies
{
    public abstract class AbstractEnemyState: IEnemyState
    {
        protected IEnemy Enemy { get; set; }
        public ISprite Sprite { get; set; }
        protected int LocationMod { get; set; }

        protected AbstractEnemyState(IEnemy enemy)
        {
            Enemy = enemy;
        }

        public virtual void ChangeDirection()
        {
        }

        public virtual void BeStomped()
        {
        }

        public virtual void BeFlipped()
        {
        }

        public virtual void Update()
        {
            Enemy.Position = new Vector2(Enemy.Position.X + LocationMod, Enemy.Position.Y);
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            Sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle GetHitBox()
        {
            return Sprite.RetrieveSpriteRectangle();
        }

        public virtual void HitFromLeft(IGameObject hittingObject)
        {
        }

        public virtual void HitFromRight(IGameObject hittingObject)
        {
        }
    }
}
