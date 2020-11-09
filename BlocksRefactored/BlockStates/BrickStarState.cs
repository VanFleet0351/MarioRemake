using SprintZero.Interfaces;
using SprintZero.Sprites.ScenerySprites;
using SprintZero.Items;
using SprintZero.Levelmanager;

namespace SprintZero.FlagPoles.BlockStates
{
    public class BrickStarState : AbstractBlockState
    {
        public BrickStarState(IBlock block): base(block)
        {
            sprite = new BreakableBlockSprite(block);
        }
        public override void BeHit()
        {
            ItemFactory.Instance.CreateStar((int)block.Position.X, (int)block.Position.Y - 32);
            block.State = new ItemBlockUsedState(block);
            SoundFactory.Instance.Play(SoundFactory.Effects.Bump);
        }
    }
}
