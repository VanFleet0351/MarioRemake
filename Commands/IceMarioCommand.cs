using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class IceMarioCommand: ICommand
    {
        private Game1 myGame;

        public IceMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Ice();
        }
    }
}
