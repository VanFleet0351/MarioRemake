using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Interfaces
{
    public interface IMarioPhysicsObject
    {
        IMario mario { get; set; }
        float gravity { get; set; }
        float aerialSpeed { get; set; }
        float maxFallSpeed { get; set; }
        float runAcceleration { get; set; }
        float runSpeed { get; set; }
        float maxRunSpeed { get; set; }
        float maxSprintSpeed { get; set; }
        float dx { get; set; }
        float dy { get; set; }
        float dt { get; set; }
        int jumptick { get; set; }

        void Jump();
        void Fall();
        void SlowDownInAir();
        void Accelerate();
        void Run(bool direction);
        void Sprint(bool direction);
        void MaintainMomentum(bool direction);
        void ResetX();
        void ResetY();
    }
}
