using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.KoopaStates
{
    public class LeftSlidingShellState: AbstractKoopaState
    {

        public LeftSlidingShellState(IEnemy enemy):base(enemy)
        {
            LocationMod = -4;
            Sprite = new ShellSprite(enemy);
        }
        public override void ChangeDirection()
        {
            Enemy.State = new RightSlidingShellState(Enemy);
            SoundFactory.Instance.Play(SoundFactory.Effects.Bump);
        }
    }
}
