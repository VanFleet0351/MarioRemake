using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.HUD;
using SprintZero.Levelmanager;

namespace SprintZero.GameStates
{
    public class PauseState : AbstractGameState
    {
        private SpriteFont font;

        public override void Initialize()
        {
            Level = myGame.currentState.Level;
            Controller = Game1.Instance.currentState.Controller;
        }

        public override void LoadContent()
        {
            font = content.Load<SpriteFont>("font");
        }

        public override void Update()
        {
            Controller.Update();
            SoundFactory.Instance.pauseSong();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Turquoise);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Paused", new Vector2(450, 360), Color.DarkMagenta, 0, new Vector2(0,0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
