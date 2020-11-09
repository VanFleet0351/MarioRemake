using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.HUD
{
    public class FloatingStat
    {
        private string statValue;
        private Vector2 PositionOnScreen;
        private int LifeTime = 20;
        

        public FloatingStat(string stat, Vector2 position)
        {
            statValue = stat;
            PositionOnScreen = position;
        }

        public void Draw(SpriteBatch spritebatch, SpriteFont font)
        {
            spritebatch.DrawString(font, statValue, PositionOnScreen, Color.White, 0, new Vector2(5, 0), 0.8f, SpriteEffects.None, 0);
        }


        public void Update()
        {
            PositionOnScreen = new Vector2(PositionOnScreen.X, PositionOnScreen.Y - 2);
            if(LifeTime++ > 80)
            {
                Game1.Instance.stats.RemoveStat(this);
            }
        }
    }
}
