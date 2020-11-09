using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Levelmanager;

namespace SprintZero.GameStates
{
    public class DeathScreenState : AbstractGameState
    {
        private SpriteFont font;
        private Texture2D sprites;
        private Rectangle spriteSource;
        private int timer = 0;

        public override void Initialize()
        {
            spriteSource = new Rectangle(23,507,13,16);
            SoundFactory.Instance.StopSong();
            Game1.Instance.stats.lives--;
        }

        public override void LoadContent()
        {
            font = content.Load<SpriteFont>("font");
            sprites = content.Load<Texture2D>("Images/allSprites");
        }

        public override void Update()
        {
            timer++;
            if (timer > 300)
            {

                if (Game1.Instance.stats.lives > 0)
                {
                    Game1.Instance.currentState = new LevelOneOneState();  
                }
                else
                {
                    Game1.Instance.currentState = new GameOverState();
                }
                Game1.Instance.stats.Reset();
                UnloadContent();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "World", new Vector2(480, 330), Color.White, 0, new Vector2(0, 0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, Game1.Instance.stats.level, new Vector2(500, 365), Color.White, 0, new Vector2(0, 0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.Draw(sprites, new Rectangle(475, 405, 26, 32), spriteSource, Color.White);
            spriteBatch.DrawString(font, "x", new Vector2(510, 405), Color.White, 0, new Vector2(0, 0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, Game1.Instance.stats.lives.ToString(), new Vector2(530, 405), Color.White,
                0, new Vector2(0, 0),
                2.0f, SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
