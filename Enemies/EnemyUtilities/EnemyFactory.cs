using Microsoft.Xna.Framework;
using SprintZero.Levelmanager;

namespace SprintZero.Enemies
{
    public class EnemyFactory
    {
        private static EnemyFactory instance;
        private Level level;

        public static EnemyFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        }

        private EnemyFactory()
        {
        }

        public void SetLevel(Level currentLevel)
        {
            level = currentLevel;
        }

        public void CreateKoopa(int locationX, int locationY)
        {
            level.AddEnemy(new Koopa(new Vector2(locationX, locationY)));
        }

        public void CreateGoomba(int locationX, int locationY)
        {
            level.AddEnemy(new Goomba(new Vector2(locationX, locationY)));
        }
    }
}
