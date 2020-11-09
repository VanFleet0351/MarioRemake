using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.GoombaStates
{
    class FlippedGoombaState: AbstractGoombaState
    {
        private int hangTime;

        public FlippedGoombaState(IEnemy goomba):base(goomba)
        {
            hangTime = 5;
            Sprite = new FlippedGoombaSprite(goomba);
        }

        public override void Update()
        {
            hangTime--;
            if (hangTime < 0)
            {
                Sprite.Update(); 
            }
        }
    }
}
