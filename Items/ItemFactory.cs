using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;

namespace SprintZero.Items
{
    public class ItemFactory
    {
        private static ItemFactory instance;
        private Level level;

        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }
                return instance;
            }
        }

        private ItemFactory()
        {
        }

        public void SetLevel(Level currentLevel)
        {
            level = currentLevel;
        }

        public void CreateCoin(int locationX, int locationY)
        {
            level.AddObject(new Coin(new Vector2(locationX, locationY)));
        }

        public void CreateFireFlower(int locationX, int locationY)
        {
            level.AddObject(new FireFlower(new Vector2(locationX, locationY)));
        }

        public void CreateIceFlower(int locationX, int locationY)
        {
            level.AddObject(new IceFlower(new Vector2(locationX, locationY)));
        }

        public void CreateGreenMushroom(int locationX, int locationY)
        {
            level.AddObject(new GreenMushroom(new Vector2(locationX, locationY)));
        }

        public void CreateRedMushRoom(int locationX, int locationY)
        {
            level.AddObject(new RedMushroom(new Vector2(locationX, locationY)));
        }

        public void CreateStar(int locationX, int locationY)
        {
            level.AddObject(new Star(new Vector2(locationX, locationY)));
        }

        public void CreateSpinningCoin(int locationX, int locationY)
        {
            level.AddObject(new SpinningCoin(new Vector2(locationX, locationY)));
        }
    }
}
