using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class SpinningCoin : AbstractItem
    {
        public SpinningCoin(Vector2 position):base(position)
        {
            Sprite = new SpinningCoinSprite(this);
            Game1.Instance.stats.AddCoin();
            Game1.Instance.stats.AddScore(200, Position);
            SoundFactory.Instance.Play(SoundFactory.Effects.Coin);
        }
    }
}
