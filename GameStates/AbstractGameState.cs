using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Levelmanager;

namespace SprintZero.GameStates
{
    public abstract class AbstractGameState : IGameState
    {
        protected ContentManager content { get; set; }
        protected Game1 myGame { get; set; }
        public Level Level { get; set; }
        public IController Controller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected AbstractGameState()
        {
            myGame = Game1.Instance;
            content = new ContentManager(myGame.Content.ServiceProvider, "Content");
            Initialize();
            LoadContent();
        }

        public virtual void Reset()
        {
            UnloadContent();
            LoadContent();
        }

        public abstract void Initialize();

        public abstract void LoadContent();

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
