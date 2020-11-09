using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;

namespace SprintZero.Items
{
    public class Star : AbstractItem
    {
        public Star(Vector2 position):base(position)
        {
            locationMod = 1;
            Sprite = new StarSprite(this);
            SoundFactory.Instance.Play(SoundFactory.Effects.PowerUpAppear);
        }
        public override void BeCollected()
        {
            Game1.Instance.stats.AddScore(1000, Position);
            base.BeCollected();
        }
    }
}
