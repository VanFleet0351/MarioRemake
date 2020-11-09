using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    public class ItemBlockUsedState: AbstractBlockState
    {
        public ItemBlockUsedState(IBlock block): base(block)
        {
            WasHit = true;
            sprite = new ItemBlockEmptySprite(block);
        }

        public override void BeHit()
        {
            base.BeHit();
            SoundFactory.Instance.Play(SoundFactory.Effects.Bump);
        }
    }
}
