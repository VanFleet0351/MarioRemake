using SprintZero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Commands
{
    class FireBallCommand : ICommand
    {
        private Game1 myGame;

        public FireBallCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if(myGame.currentState.Level.GetFireballs().Count < 2)
                myGame.currentState.Level.Player.UsePower();
        }
    }
}
