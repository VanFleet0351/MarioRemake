using SprintZero.Levelmanager;
using SprintZero.ScreenCamera;
using System.Collections.Generic;

namespace SprintZero.Enemies.EnemyUtilities
{
    public class EnemySpawner
    {
        private static EnemySpawner instance;
        private readonly PlayerOneCamera camera = PlayerOneCamera.Instance;
        public struct EnemyInfo
        {
            public string enemyType { get; set; }
            public int x {get; set; }
            public int y {get; set; }

            public EnemyInfo(string name, int locationX, int locationY)
            {
                enemyType = name;
                x = locationX;
                y = locationY;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        private List<EnemyInfo> enemies = new List<EnemyInfo>();

        public static EnemySpawner Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EnemySpawner();
                }
                return instance;
            }
        }

        public void AddEnemy(string name, int locationX, int locationY)
        {
            EnemyInfo enemy = new EnemyInfo(name, locationX, locationY);
            enemies.Add(enemy);
        }

        public void Reset()
        {
            enemies.Clear();
        }

        private EnemySpawner()
        {
        }

        public void Update()
        {
            List<EnemyInfo> enemiesCopy = new List<EnemyInfo>(enemies);
            foreach(EnemyInfo enemy in enemiesCopy)
            {
                if(camera.RightBound+600 >= enemy.x)
                {
                    if (enemy.enemyType.Equals("Koopa"))
                    {
                        EnemyFactory.Instance.CreateKoopa(enemy.x, enemy.y);
                        enemies.Remove(enemy);
                    }
                    else if (enemy.enemyType.Equals("Goomba"))
                    {
                        EnemyFactory.Instance.CreateGoomba(enemy.x, enemy.y);
                        enemies.Remove(enemy);
                    }
                }
            }
        }
    }
}
