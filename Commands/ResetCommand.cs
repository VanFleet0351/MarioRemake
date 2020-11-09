using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;

namespace SprintZero.Commands
{
    class ResetCommand : ICommand
    {
        Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.currentState.Reset();
        }
    }
}
