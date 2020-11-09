using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Player;


namespace SprintZero.Enemies.KoopaStates
{
    public abstract class AbstractKoopaState: AbstractEnemyState
    {
        protected AbstractKoopaState(IEnemy enemy) : base(enemy)
        {
        }

        public override void BeFlipped()
        {
            Enemy.State = new FlippedKoopaState(Enemy);
            Game1.Instance.stats.AddScore(200, Enemy.Position);
        }

        public override void BeStomped()
        {
            Enemy.State = new StompedKoopaState(Enemy);
        }

        public override void HitFromLeft(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                BeFlipped();
                SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
            }
        }

        public override void HitFromRight(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                BeFlipped();
                SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
            }
        }
    }
}
