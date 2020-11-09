using SprintZero.Interfaces;
using SprintZero.Sprites.EnemySprites;

namespace SprintZero.Enemies.KoopaStates
{
    class FlippedKoopaState: AbstractKoopaState
    {
        private int hangTime;

        public FlippedKoopaState(IEnemy enemy):base(enemy)
        {
            hangTime = 5;
            Sprite = new FlippedKoopaSprite(enemy);
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
