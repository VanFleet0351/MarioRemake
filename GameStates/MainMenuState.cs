
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Levelmanager;
using SprintZero.Scenery;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.GameStates
{
    public class MainMenuState : AbstractGameState
    {
        private Texture2D allSpriteSheet { get; set; }
        private SpriteFont font;

        public override void Initialize()
        {
            Controller = new KeyboardController(myGame);
            SoundFactory.Instance.Play(SoundFactory.ThemeSongs.MainTheme);
        }

        public override void LoadContent()
        {
            allSpriteSheet = content.Load<Texture2D>("Images/allSprites");
            font = content.Load<SpriteFont>("font");
        }

        public override void Update()
        {
            Controller.Update();
        }

        public override void Reset()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(new Color(0.39f, 0.58f, 0.95f));
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SUPER MARIO BROS.", new Vector2(275, 200), Color.White, 0, new Vector2(0, 0), 4.0f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Start Game", new Vector2(450, 400), Color.White, 0, new Vector2(0,0), 1.5F, SpriteEffects.None, 0);

            //draw background
            for(int i = 0; i * 32 < 1024; i++)
            {
                ISprite block = new GroundBlockSprite(0 + (i * 32), 688);
                block.Draw(spriteBatch, allSpriteSheet, Color.White);
            }

            ISprite hill = new SmallHillSprite(20, 688);
            hill.Draw(spriteBatch, allSpriteSheet, Color.White);
            hill = new SmallHillSprite(770, 688);
            hill.Draw(spriteBatch, allSpriteSheet, Color.White);
            hill = new BigHillSprite(420, 688);
            hill.Draw(spriteBatch, allSpriteSheet, Color.White);

            ISprite cloud = new Cloud1Sprite(60, 150);
            cloud.Draw(spriteBatch, allSpriteSheet, Color.White);
            cloud = new Cloud2Sprite(600, 100);
            cloud.Draw(spriteBatch, allSpriteSheet, Color.White);
            cloud = new Cloud3Sprite(350, 200);
            cloud.Draw(spriteBatch, allSpriteSheet, Color.White);
      
            ISprite bush = new Bush1Sprite(120, 688);
            bush.Draw(spriteBatch, allSpriteSheet, Color.White);
            bush = new Bush2Sprite(800, 688);
            bush.Draw(spriteBatch, allSpriteSheet, Color.White);
            bush = new Bush3Sprite(200, 688);
            bush.Draw(spriteBatch, allSpriteSheet, Color.White);

            spriteBatch.End();
        }
    }
}