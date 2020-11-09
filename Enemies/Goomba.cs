using Microsoft.Xna.Framework;
using SprintZero.Enemies.GoombaStates;


namespace SprintZero.Enemies
{
    public class Goomba: AbstractEnemy
    {
        public Goomba(Vector2 position):base(position)
        {
            State = new LeftMovingGoombaState(this);
        }
    }
}
