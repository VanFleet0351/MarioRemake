using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class UseStoredItemCommand : ICommand
    {
        private Game1 myGame;

        public UseStoredItemCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.UseStoredItem();
        }
    }
}
