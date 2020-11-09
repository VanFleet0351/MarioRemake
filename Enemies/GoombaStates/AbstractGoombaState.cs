using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Player;


namespace SprintZero.Enemies.GoombaStates
{
    public abstract class AbstractGoombaState: AbstractEnemyState
    {
        protected AbstractGoombaState(IEnemy goomba):base(goomba)
        {
        }

        public override void BeStomped()
        {
            Enemy.State = new StompedGoombaState(Enemy);
            Game1.Instance.stats.AddScore(100, Enemy.Position);
        }

        public override void BeFlipped()
        {
            Game1.Instance.stats.AddScore(100, Enemy.Position);
            Enemy.State = new FlippedGoombaState(Enemy);
            
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
            HitFromLeft(hittingObject);
        }
    }
}
