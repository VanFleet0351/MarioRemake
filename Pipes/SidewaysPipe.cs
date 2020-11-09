using Microsoft.Xna.Framework;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Sprites.PipeSprites;
using System.Diagnostics;

namespace SprintZero.Pipes
{
    public class SidewaysPipe : AbstractPipe
    {
        public SidewaysPipe(int locationX, int locationY) : base(locationX, locationY)
        {
            Sprite = new SidewaysPipeSprite(this);

        }

        public void EnterPipe()
        {
            PipeTransitionState newGameState = new PipeTransitionState();
            newGameState.pipe = this;
            Game1.Instance.currentState = newGameState;
        }

    }
}
