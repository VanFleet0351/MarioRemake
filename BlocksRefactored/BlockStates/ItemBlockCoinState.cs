using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    public class ItemBlockCoinState : AbstractBlockState
    {
        public ItemBlockCoinState(IBlock block): base(block)
        {
            sprite = new ItemBlockSprite(block);
        }

        public override void BeHit()
        {
            ItemFactory.Instance.CreateSpinningCoin((int)block.Position.X, (int)block.Position.Y);
            block.State = new ItemBlockUsedState(block);
        }
    }
}
