using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.KoopaStates
{
    class RightMovingKoopaState: AbstractKoopaState
    {

        public RightMovingKoopaState(IEnemy enemy):base(enemy)
        {
            LocationMod = 1;
            Sprite = new RightMovingKoopaSprite(enemy);
        }

        public override void ChangeDirection()
        {
            Enemy.State = new LeftMovingKoopaState(Enemy);
        }
        public override void BeStomped()
        {
            base.BeStomped();
            Game1.Instance.stats.AddScore(100, Enemy.Position);
        }
    }
}
