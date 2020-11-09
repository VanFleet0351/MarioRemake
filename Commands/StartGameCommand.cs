using SprintZero.GameStates;
using SprintZero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Commands
{
    class StartGameCommand : ICommand
    {
        private Game1 myGame;

        public StartGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if(myGame.currentState is MainMenuState)
                myGame.currentState = new LevelOneOneState();
        }
    }
}
