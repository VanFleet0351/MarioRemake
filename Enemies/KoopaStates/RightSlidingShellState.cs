using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Player;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.KoopaStates
{
    public class RightSlidingShellState: AbstractKoopaState
    {
        public RightSlidingShellState(IEnemy enemy):base(enemy)
        {
            LocationMod = 4;
            Sprite = new ShellSprite(enemy);
        }

        public override void BeStomped()
        {
            Enemy.State = new StompedKoopaState(Enemy);
        }

        public override void ChangeDirection()
        {
            Enemy.State = new LeftSlidingShellState(Enemy);
            SoundFactory.Instance.Play(SoundFactory.Effects.Bump);
        }

        public override void HitFromLeft(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                base.HitFromRight(hittingObject);
            }
            else
            {
                Enemy.State = new RightSlidingShellState(Enemy);
            }
        }

        public override void HitFromRight(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                base.HitFromRight(hittingObject);
            }
            else
            {
                Enemy.State = new LeftSlidingShellState(Enemy);
            }
        }
    }
}
