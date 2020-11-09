using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.GoombaStates
{
    class StompedGoombaState: AbstractGoombaState
    {
        public StompedGoombaState(IEnemy goomba):base(goomba)
        {
            Sprite = new StompedGoombaSprite(goomba);
        }
    }
}
