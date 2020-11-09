using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Sprites.ScenerySprites;
using System;

namespace SprintZero.FlagPoles.BlockStates
{
    public class ItemBlockPowerUpState : AbstractBlockState
    {

        public ItemBlockPowerUpState(IBlock block): base(block)
        {
            sprite = new ItemBlockSprite(block);
        }

        public override void BeHit()
        {
            Random random = new Random();
            double x = random.NextDouble();
            if(x < 0.5)
                ItemFactory.Instance.CreateFireFlower((int) block.Position.X, (int) block.Position.Y-32);
            else
                ItemFactory.Instance.CreateIceFlower((int)block.Position.X, (int)block.Position.Y - 32);

            block.State = new ItemBlockUsedState(block);
        }

        public override void BeBumped()
        {
            ItemFactory.Instance.CreateRedMushRoom((int)block.Position.X, (int)block.Position.Y - 32);
            block.State = new ItemBlockUsedState(block);
        }
    }
}
