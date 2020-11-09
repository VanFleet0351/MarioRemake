using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class UpCommand: ICommand
    {
        private Game1 myGame;

        public UpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Jump();
        }
    }
}
