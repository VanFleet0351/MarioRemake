using Microsoft.Xna.Framework;

namespace SprintZero.Interfaces
{
    public interface IHittable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        Rectangle GetHitBox();
    }
}
