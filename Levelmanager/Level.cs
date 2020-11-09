using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Exits;
using SprintZero.Interfaces;
using SprintZero.Fireball;
using System.Collections.Generic;
using SprintZero.ParticleEffects;
using System.Collections.ObjectModel;
using SprintZero.ScreenCamera;
using SprintZero.Iceball;

namespace SprintZero.Levelmanager
{
    public class Level
    {
        private Collection<IEnemy> Enemies = new Collection<IEnemy>();
        private Collection<IItem> Items = new Collection<IItem>();
        private Collection<IGameObject> GameObjects = new Collection<IGameObject>();
        public  Collection<IGameObject> individualFloorBlock = new Collection<IGameObject>();
        public Collection<IGameObject> BigFloorRectangles = new Collection<IGameObject>();
        private Collection<ISprite> BackGroundImages = new Collection<ISprite>();
        private Collection<FireballObject> Fireballs = new Collection<FireballObject>();
        private Collection<IceballObject> Iceballs = new Collection<IceballObject>();
        public IMario Player { get; set; }
        private Collection<IExit> ExitObjects = new Collection<IExit>();
        private Collection<IGameObject> removeList = new Collection<IGameObject>();
        private Collection<ParticleEngine> particles = new Collection<ParticleEngine>();
        private Collection<ParticleEngine> removeParticles = new Collection<ParticleEngine>();

        public void AddExit(IExit exit)
        {
            ExitObjects.Add(exit);
        }

        public void AddPartcleEngine(ParticleEngine engine)
        {
            particles.Add(engine);
        }

        public void RemoveParticleEngine(ParticleEngine engine)
        {
            removeParticles.Add(engine);
        }

        public void RemoveFromLevel(IGameObject gameObject)
        {
            removeList.Add(gameObject);
        }

        private void UnloadDeadObjects()
        {
           foreach(IGameObject gameObject in removeList)
           {
                if(gameObject is IEnemy enemy)
                {
                    Enemies.Remove(enemy);
                }
                else if(gameObject is IItem item)
                {
                    Items.Remove(item);
                }
                else if(gameObject is FireballObject fireball)
                {
                    Fireballs.Remove(fireball);
                }
                else if (gameObject is IceballObject iceball)
                {
                    Iceballs.Remove(iceball);
                }
                else
                {
                    GameObjects.Remove(gameObject);
                }
           }
           foreach(ParticleEngine engine in removeParticles)
            {
                particles.Remove(engine);
            }
            removeParticles.Clear();
            removeList.Clear();
        }


        public void AddObject(IGameObject gameObj)
        {
            if (gameObj is IItem)
            {
                Items.Add((IItem)gameObj);
            }
            else if (gameObj is FireballObject)
            {
                Fireballs.Add((FireballObject)gameObj);
            }
            else if (gameObj is IceballObject)
            {
                Iceballs.Add((IceballObject)gameObj);
            }
            else
            {
                GameObjects.Add(gameObj);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<IGameObject> GetObjects()
        {
            return GameObjects;
        }

        public Collection<IGameObject> GetOnScreenObjects()
        {
            Collection<IGameObject> onScreenObjects = new Collection<IGameObject>();
            foreach (IGameObject tempObject in GameObjects)
            {
                if (tempObject.Position.X > (PlayerOneCamera.Instance.LeftBound - 100) && tempObject.Position.X < (PlayerOneCamera.Instance.RightBound + 200))
                {
                    onScreenObjects.Add(tempObject);
                }
            }
            return onScreenObjects; 
        }

        public void RemoveObject(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public void AddEnemy(IGameObject enemy)
        {
            Enemies.Add((IEnemy)enemy);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<IEnemy> GetEnemies()
        {
            return Enemies;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<IItem> GetItems()
        {
            return Items;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<FireballObject> GetFireballs()
        {
            return Fireballs;
        }
        public Collection<IceballObject> GetIceballs()
        {
            return Iceballs;
        }

        public void AddBackGroundImage(ISprite backGround)
        {
            BackGroundImages.Add(backGround);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<ISprite> getBackGround()
        {
            return BackGroundImages;
        }

        public void Update()
        {
            UnloadDeadObjects();
            foreach (IGameObject gameObject in GameObjects)
            {
                gameObject.Update();
            }
            foreach (ISprite scenery in BackGroundImages)
            {
                scenery.Update();
            }
            foreach(IItem item in Items)
            {
                item.Update();
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update();
            }
            foreach(ParticleEngine engine in particles)
            {
                engine.Update();
            }
            foreach (FireballObject fireball in Fireballs)
            {
                fireball.Update();
            }
            foreach (IceballObject iceball in Iceballs)
            {
                iceball.Update();
            }
            Player.Update();
            foreach (IExit exit in ExitObjects)
            {
                exit.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
            foreach (ISprite scenery in BackGroundImages)
            {
                scenery.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach(IGameObject block in individualFloorBlock)
            {
                block.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach (IGameObject gameObject in GameObjects)
            {
                gameObject.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach (IGameObject enemy in Enemies)
            {
                enemy.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach(ParticleEngine engine in particles)
            {
                engine.Draw(spriteBatch);
            }
            foreach(FireballObject fireball in Fireballs)
            {
                fireball.Draw(spriteBatch, allSpriteSheet, color);
            }
            foreach (IceballObject iceball in Iceballs)
            {
                iceball.Draw(spriteBatch, allSpriteSheet, color);
            }
            Player.Draw(spriteBatch, allSpriteSheet, color);
            foreach (IExit exit in ExitObjects)
            {
                exit.Draw(spriteBatch, allSpriteSheet, color);
            }
        }
    }
}
