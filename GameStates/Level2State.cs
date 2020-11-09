using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Collision;
using SprintZero.Enemies;
using SprintZero.Enemies.EnemyUtilities;
using SprintZero.Items;
using SprintZero.Levelmanager;
using SprintZero.ScreenCamera;


namespace SprintZero.GameStates
{
    public class Level2State: AbstractGameState
    {
        private Texture2D allSpriteSheet { get; set; }
        private CollisionDetection collisionHandler { get; set; }
        private LevelManager levelManager { get; set; }

        public override void Initialize()
        {
            Controller = new KeyboardController(myGame);
            levelManager = new LevelManager("Levelmanager/Level2.xml");
            levelManager.LoadLevel();
            Level = levelManager.GetCurrentLevel();
            ItemFactory.Instance.SetLevel(Level);
            EnemyFactory.Instance.SetLevel(Level);
            collisionHandler = new CollisionDetection(Level);
            SoundFactory.Instance.Play(SoundFactory.ThemeSongs.MainTheme);
            PlayerOneCamera.Instance.Reset();
        }

        public override void LoadContent()
        {
            allSpriteSheet = content.Load<Texture2D>("Images/allSprites");
        }

        public override void Update()
        {
            Controller.Update();
            Level.Update();
            collisionHandler.DetectCollision(Level.Player);
            PlayerOneCamera.Instance.Update();
            EnemySpawner.Instance.Update();
            SoundFactory.Instance.resumeSong();
            if (Level.Player.IsMarioDead())
            {
                EnemySpawner.Instance.Reset();
                Game1.Instance.currentState = new DeathScreenState();
                UnloadContent();
            }
        }

        public override void Reset()
        {
            EnemySpawner.Instance.Reset();
            Initialize();
            base.Reset();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(new Color(0.39f, 0.58f, 0.95f));
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, PlayerOneCamera.Instance.View);
            Level.Draw(spriteBatch, allSpriteSheet, Color.White);
            spriteBatch.End();
        }
    }
}
