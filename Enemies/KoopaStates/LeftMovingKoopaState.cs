using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.KoopaStates
{
    class LeftMovingKoopaState: AbstractKoopaState
    {

        public LeftMovingKoopaState(IEnemy enemy):base(enemy)
        {
            LocationMod = -1;
            Sprite = new MovingKoopaSprite(Enemy);
        }

        public override void ChangeDirection()
        {
            Enemy.State = new RightMovingKoopaState(Enemy);
        }
        public override void BeStomped()
        {
            base.BeStomped();
            Game1.Instance.stats.AddScore(100, Enemy.Position);
        }
    }
}
