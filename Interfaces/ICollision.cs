using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Interfaces
{

    public interface ICollision
    {
        Rectangle CollisionIntersection { get; }
    }
}
