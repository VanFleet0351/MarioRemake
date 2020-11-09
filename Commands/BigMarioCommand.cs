using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Player;

namespace SprintZero.Commands
{
    class BigMarioCommand: ICommand
    {
        private Game1 myGame;

        public BigMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Big();
        }
    }
}
