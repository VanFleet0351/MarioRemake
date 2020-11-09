using SprintZero.GameStates;
using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class PauseCommand : ICommand
    {
        private Game1 myGame;

        public PauseCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.currentState is PauseState)
            {
                myGame.currentState = myGame.savedState;
            }
            else
            {
                myGame.savedState = myGame.currentState;
                myGame.currentState = new PauseState();
            }
        }
    }
}
