using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Items;

namespace SprintZero.Collision
{
    public static class ItemCollisionResponder
    {

        public static void MarioCollideWithItem(IMario mario, IItem item)
        {
            item.BeCollected();
            if (item is Star)
            {
                new StarMario(mario, Game1.Instance);
            }
            else if (item is FireFlower)
            {
                if ((mario.FireMario == true || mario.IceMario == true) && mario.hasStoredItem == false)
                {
                    mario.hasStoredItem = true;
                    mario.storedItemInt = 1;
                }
                else
                {
                    mario.Fire();
                }
            }
            else if (item is RedMushroom)
            {
                if (mario.BigMario == true && mario.hasStoredItem == false)
                {
                    mario.hasStoredItem = true;
                    mario.storedItemInt = 2; 
                }
                mario.Big();
            }
            else if (item is IceFlower)
            {
                if ((mario.FireMario == true || mario.IceMario == true) && mario.hasStoredItem == false)
                {
                    mario.hasStoredItem = true;
                    mario.storedItemInt = 3;
                }
                else
                {
                    mario.Ice();
                }
            }
        }
    }
}
