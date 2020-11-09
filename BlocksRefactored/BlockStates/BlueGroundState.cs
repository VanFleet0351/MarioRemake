using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Sprites.BlockSprites;

namespace SprintZero.BlocksRefactored.BlockStates
{
    public class BlueGroundState: GroundBlockState
    {
        public BlueGroundState(IBlock block) : base(block)
        {
            sprite = new BlueFloorBlock(block);
        }
    }
}
