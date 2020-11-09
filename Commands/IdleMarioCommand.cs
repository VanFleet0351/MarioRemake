using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.MarioStatePattern;

namespace SprintZero.Commands
{
    class IdleMarioCommand: ICommand
    {
        private Game1 myGame;

        public IdleMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.currentState.Level.Player.isFalling || myGame.currentState.Level.Player.isJumping)
            {
                myGame.currentState.Level.Player.Fall();
            }
            else
            {
                myGame.currentState.Level.Player.Idle();
            }
        }
    }
}
