using Microsoft.Xna.Framework.Graphics;
using SprintZero.Levelmanager;

namespace SprintZero.GameStates
{
    public interface IGameState
    {
        Level Level { get; set; }
        IController Controller { get; set; }

        void Initialize();
        void LoadContent();
        void UnloadContent();
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void Reset();
    }
}
