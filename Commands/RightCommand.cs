using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class RightCommand: ICommand
    {
        private Game1 myGame;

        public RightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.WalkRight();
        }
    }
}
