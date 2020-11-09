using System;
using SprintZero.Interfaces;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    class UnbreakableBlockState : AbstractBlockState
    {
        public UnbreakableBlockState(IBlock block):base(block)
        {
            sprite = new UnbreakableBlockSprite(block);
        }
    }
}
