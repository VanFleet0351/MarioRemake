using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SprintZero.HUD;
using SprintZero.GameStates;
using System.Collections.ObjectModel;

namespace SprintZero
{
    public class Game1 : Game
    {
        private static Game1 instance;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public GameTime gameTime { get; set; }
        public GameStats stats { get; set; }
        public IGameState currentState { get; set; }
        public IGameState savedState { get; set; }
        public Texture2D circleSprite { get; set; }
        public Texture2D starSprite { get; set; }
        public Texture2D diamondSprite { get; set; }
        public Texture2D squareSprite { get; set; }
        public Texture2D spiralSprite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private Collection<Texture2D> particleTextures;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private Texture2D allSpriteSheet;


        public static Game1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game1
                    {
                    };
                    instance.graphics = new GraphicsDeviceManager(instance)
                    {
                        PreferredBackBufferWidth = 1024,
                        PreferredBackBufferHeight = 720
                    };
                    instance.Content.RootDirectory = "Content";
                }
                return instance;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            currentState = new MainMenuState();
            stats = new GameStats();
        }

        protected override void LoadContent()
        {
            allSpriteSheet = Content.Load<Texture2D>("Images/allSprites");
            circleSprite = Content.Load<Texture2D>("circle");
            squareSprite = Content.Load<Texture2D>("square");
            starSprite = Content.Load<Texture2D>("star");
            diamondSprite = Content.Load<Texture2D>("diamond");
            spiralSprite = Content.Load<Texture2D>("spiral");
            particleTextures = new Collection<Texture2D>
            {
                circleSprite,
                squareSprite,
                starSprite,
                diamondSprite,
                spiralSprite
            };
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            stats.Update();
            currentState.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            currentState.Draw(spriteBatch);
            spriteBatch.Begin();
            stats.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            instance = new Game1();
        }
    }
}
