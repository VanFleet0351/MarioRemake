using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class SprintCommand: ICommand
    {
        private Game1 myGame;

        public SprintCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Sprint();
        }
    }
}
