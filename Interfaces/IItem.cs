using Microsoft.Xna.Framework;

namespace SprintZero.Interfaces
{
    public interface IItem: IGameObject
    {
        bool IsFalling { get; set; }
        IItemPhysicsObject physicsObject {get; set;}
        void BeCollected();
        void Fall();
    }
}
