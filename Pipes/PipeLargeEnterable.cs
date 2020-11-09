using Microsoft.Xna.Framework;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Sprites.PipeSprites;
using System.Diagnostics;

namespace SprintZero.Pipes
{
    public class PipeLargeEnterable: AbstractPipe
    {
        public PipeLargeEnterable(int locationX, int locationY) : base(locationX, locationY)
        {
            Sprite = new PipeLargeSprite(this);

        }

    }
}
