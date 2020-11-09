
namespace SprintZero.Interfaces
{
    public interface IMarioState
    {
        void WalkLeft();
        void WalkRight();
        void Sprint();
        void Jump();
        void Fall();
        void Land();
        void Crouch();
        void Idle();
        void Climb();
        void GetHit();
        void Big();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        void Fire();
        void Ice();
        void Star();
        void Die();
        void Update();
    }
}
