using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class LeftCommand: ICommand
    {
        private Game1 myGame;

        public LeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.WalkLeft();
        }
    }
}
