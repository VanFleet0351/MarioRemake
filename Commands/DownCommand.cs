using SprintZero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Commands
{
    class DownCommand: ICommand
    {
        private Game1 myGame;

        public DownCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Crouch();
        }
    }
}
