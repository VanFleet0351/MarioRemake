using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class Coin: AbstractItem
    {
        public Coin (Vector2 position):base(position)
        {
            Sprite = new CoinSprite(this);
        }

        public override void BeCollected()
        {
            base.BeCollected();
            Game1.Instance.stats.AddCoin();
            Game1.Instance.stats.AddScore(200);
            SoundFactory.Instance.Play(SoundFactory.Effects.Coin);
        }

        public override void Update()
        {
            Sprite.Update();
        }
    }
}
