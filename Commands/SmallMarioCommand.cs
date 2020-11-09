using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;

namespace SprintZero.Commands
{
    class SmallMarioCommand: ICommand
    {
        private Game1 myGame;

        public SmallMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IMario newMario = new Mario(new Vector2(myGame.currentState.Level.Player.Position.X, myGame.currentState.Level.Player.Position.Y));
            myGame.currentState.Level.Player = newMario;
        }
    }
}
