using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class FireMarioCommand : ICommand
    {
        private Game1 myGame;

        public FireMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Fire();
        }
    }
}
