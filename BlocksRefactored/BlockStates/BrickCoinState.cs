using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    public class BrickCoinState : AbstractBlockState
    {
        private int hitCount;
        private int hitStall;

        public BrickCoinState(IBlock block) : base(block)
        {
            sprite = new BreakableBlockSprite(block);
        }
        public override void BeHit()
        {

            if (hitStall > 30)
            {
                hitStall = 0;
                hitCount++;
                ItemFactory.Instance.CreateSpinningCoin((int)block.Position.X, (int)block.Position.Y);
                WasHit = true;
            }
            
            if(hitCount >= 10)
            {
                block.State = new ItemBlockUsedState(block);
            }

        }

        public override void Update()
        {
            base.Update();
            hitStall++;
        }
    }
}
