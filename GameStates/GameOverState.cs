using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.HUD;
using SprintZero.Levelmanager;

namespace SprintZero.GameStates
{
    public class GameOverState : AbstractGameState
    {
        private SpriteFont font;
        private int timer = 0;

        public override void Initialize()
        {
            SoundFactory.Instance.Play(SoundFactory.ThemeSongs.GameOver);
        }

        public override void LoadContent()
        {
            font = content.Load<SpriteFont>("font");
        }

        public override void Update()
        {
            timer++;
            if (timer > 360)
            {
                Game1.Instance.stats = new GameStats();
                Game1.Instance.currentState = new LevelOneOneState();
                UnloadContent();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Game Over", new Vector2(450, 360), Color.White, 0, new Vector2(0,0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
