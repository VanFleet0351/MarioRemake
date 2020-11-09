using Microsoft.Xna.Framework;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles.BlockStates
{
    public class BrickBlockState : AbstractBlockState
    {
        public BrickBlockState(IBlock block): base(block)
        {
            sprite = new BreakableBlockSprite(block);
        }

        public override void BeHit()
        {
                WasHit = true;
                Game1.Instance.stats.AddScore(50);
                sprite = new BrokenBlockSprite(block);
                SoundFactory.Instance.Play(SoundFactory.Effects.BreakBlock);
        }

        public override void BeBumped()
        {
            WasHit = true;
            SoundFactory.Instance.Play(SoundFactory.Effects.Bump);
        }
    }
}
