
using Microsoft.Xna.Framework;

namespace SprintZero.Interfaces
{
    public interface IEnemy: IGameObject
    {
        bool IsFalling { get; set; }
        bool IsFrozen { get; set; }
        IEnemyPhysicsObject PhysicsObject { get; set; }
        IEnemyState State { get; set; }

        void BeStomped();
        void BeFlipped();
        void Fall();
        void Freeze();
        void HitFromLeft(IGameObject hittingObject);
        void HitFromRight(IGameObject hittingObject);
    }
}
