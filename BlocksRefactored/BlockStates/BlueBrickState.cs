using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;
using SprintZero.Sprites.BlockSprites;

namespace SprintZero.BlocksRefactored.BlockStates
{
    public class BlueBrickState: BrickBlockState
    {
        public BlueBrickState(IBlock block) : base(block)
        {
            sprite = new BlueBrickBlockSprite(block);
        }
    }
}
