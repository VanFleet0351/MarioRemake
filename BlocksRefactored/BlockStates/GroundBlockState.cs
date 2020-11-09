using SprintZero.Interfaces;
using SprintZero.Sprites.ScenerySprites;
using System;

namespace SprintZero.FlagPoles.BlockStates
{
    public class GroundBlockState : AbstractBlockState
    {
        public GroundBlockState(IBlock block): base(block)
        {
            sprite = new GroundBlockSprite(block);
        }
    }
}
