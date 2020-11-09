using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.GoombaStates
{
    class RightMovingGoombaState : AbstractGoombaState
    {

        public RightMovingGoombaState(IEnemy goomba):base(goomba)
        {
            LocationMod = 1;
            Sprite = new MovingGoombaSprite(goomba);
        }

        public override void ChangeDirection()
        {
            Enemy.State = new LeftMovingGoombaState(Enemy);
        }
    }
}
