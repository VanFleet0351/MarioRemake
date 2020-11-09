﻿using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    class MarioDieCommand : ICommand
    {
        private Game1 myGame;

        public MarioDieCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentState.Level.Player.Die();
        }
    }
}
