using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.ParticleEffects
{
    public class ParticleEngine
    {
        /*
         * This class and code was modified from http://rbwhitaker.wikidot.com/2d-particle-engine-1.
         */
        private Random random;
        private Vector2 EmitterLocation;
        private Collection<Particle> particles;
        private Collection<Texture2D> textures;
        private float blueMin;
        private float blueMax;
        private float redMin;
        private float redMax;
        private float greenMin;
        private float greenMax;
        private int total;
        private IGameObject gameObject;

        public ParticleEngine(Collection<Texture2D> textures, IGameObject location)
        {
            gameObject = location;
            this.textures = textures;
            particles = new Collection<Particle>();
            random = new Random();
            blueMin = 0;
            blueMax = 1;
            redMax = 1;
            redMin = 0;
            greenMax = 1;
            greenMin = 0;
            total = 10;
            Game1.Instance.currentState.Level.AddPartcleEngine(this);
        }

        public void Update()
        {
            int spawnX = random.Next(gameObject.GetHitBox().Left, gameObject.GetHitBox().Right);
            int spawnY = random.Next(gameObject.GetHitBox().Top, gameObject.GetHitBox().Bottom);
            EmitterLocation = new Vector2(spawnX, spawnY);
            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Destroy()
        {
            Game1.Instance.currentState.Level.RemoveParticleEngine(this);
        }

        public void SetIntensity(int numOfParticles)
        {
            total = numOfParticles;
        }

        public void SetColors(float redMinPercent, float redMaxPercent, float greenMinPercent, float greenMaxPercent, float blueMinPercent, float blueMaxPercent)
        {
            blueMax = blueMaxPercent;
            blueMin = blueMinPercent;
            redMax = redMaxPercent;
            redMin = redMinPercent;
            greenMax = greenMaxPercent;
            greenMin = greenMinPercent;
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                                    1f * (float)(random.NextDouble() *2 - 1),
                                    1f * (float)(random.NextDouble() *2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                        ((float)random.NextDouble()*(redMax-redMin) + redMin),
                        ((float)random.NextDouble()*(greenMax-greenMin)+greenMin),
                        ((float)random.NextDouble()*(blueMax - blueMin) + blueMin),
                        ((float)random.NextDouble()*0.5f)+0.5f);
            float size = (float)random.NextDouble()/4;
            int ttl = 20 + random.Next(10);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }
    }
}
