using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class RedMushroom : AbstractItem
    {
        public RedMushroom(Vector2 position): base(position)
        {
            locationMod = 1;
            Sprite = new RedMushroomSprite(this);
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUpAppear);
        }
        public override void BeCollected()
        {
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUp);
            Game1.Instance.stats.AddScore(1000, Position);
            base.BeCollected();
        }
    }
}
