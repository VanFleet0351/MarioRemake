using SprintZero.Decorator;
using SprintZero.Fireball;
using SprintZero.Iceball;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Collision
{

    public static class MasterCollisionResponder
    {
        public static void BlockCollision(IMario mario, IGameObject collidedItem)
        {
            BlockCollisionResponder.MarioCollideWithBlock(mario, collidedItem);
        }

        public static void ItemCollision(IMario mario, IItem item)
        {
            ItemCollisionResponder.MarioCollideWithItem(mario, item);
        }

        public static void PipeCollision(IMario mario, IGameObject pipe)
        {
            PipeCollisionResponder.MarioCollideWithPipe(mario, (IPipe)pipe);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void EnemyCollision(IMario mario, IEnemy enemy)
        {
            if(!(mario is ShrunkenMario))
                EnemyCollisionResponder.MarioCollideWithEnemy(mario, enemy);
        }

        public static void EnemyEnvironmentCollision(IEnemy enemy, IGameObject collidedObject)
        {
            EnemyCollisionWithEnvironmentResponder.EnemyCollideWithEnvironment(enemy, collidedObject);
        }
        
        public static void ItemEnvironmentCollision(IItem item, IGameObject collidedObject)
        {
            ItemCollisionWithEnvironmentResponder.ItemCollideWithEnvironment(item, collidedObject);
        }

        public static void FireballCollision(FireballObject fireball)
        {
            FireballCollisionDetection.DetectCollision(fireball);
        }

        public static void IceballCollision(IceballObject iceball)
        {
            IceballCollisionDetection.DetectCollision(iceball);
        }
    }
}
