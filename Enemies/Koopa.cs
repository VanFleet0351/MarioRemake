using Microsoft.Xna.Framework;
using SprintZero.Enemies.KoopaStates;

namespace SprintZero.Enemies
{
    public class Koopa: AbstractEnemy
    {

        public Koopa(Vector2 position):base(position)
        {
            State = new LeftMovingKoopaState(this);
        }
    }
}
