using System;
using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    public class HiddenItemBlockState : AbstractBlockState
    {
        public HiddenItemBlockState(IBlock block) : base(block)
        {
            sprite = new HiddenBlockSprite(block);
        }

        public override void BeHit()
        {
            ItemFactory.Instance.CreateGreenMushroom((int)block.Position.X, (int)block.Position.Y - 32);
            block.State = new ItemBlockUsedState(block);
        }
    }
}
