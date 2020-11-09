using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class FireFlower : AbstractItem
    {
        public FireFlower (Vector2 position): base(position)
        {
            Sprite = new FireFlowerSprite(this);
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUpAppear);
        }

        public override void BeCollected()
        {
            Game1.Instance.stats.AddScore(1000, Position);
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUp);
            base.BeCollected();
        }
    }
}
