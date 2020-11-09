
using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class GreenMushroom : AbstractItem
    {

        public GreenMushroom(Vector2 position) :base(position)
        {
            locationMod = 1;
            Sprite = new GreenMushroomSprite(this);
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUpAppear);
        }

        public override void BeCollected()
        {
            SoundFactory.Instance.Play(SoundFactory.Effects.OneUp);
            Game1.Instance.stats.AddLives(Position);
            base.BeCollected();
        }
    }
}
