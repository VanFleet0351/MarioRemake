using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.ParticleEffects;
using SprintZero.Sprites.ItemSprites;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.Fireball
{
    public class FireballObject : IGameObject
    {
        public int Timer { get; set; }
        public int Lifetime { get; set; }
        public FireballSprite Sprite { get; set; }
        public FireballPhysicsObject PhysicsObject { get; set; }
        public Vector2 Position { get; set; }
        private ParticleEngine particles;

        public FireballObject(float locationX, float locationY, bool direction)
        {
            Position = new Vector2(locationX, locationY);
            Sprite = new FireballSprite(this);
            Timer = 0;
            Lifetime = 300;
            particles = new ParticleEngine(new Collection<Texture2D> { Game1.Instance.circleSprite }, this);
            particles.SetColors(1, 1, 0, 1, 0, 0);
            PhysicsObject = new FireballPhysicsObject(this, direction);
            SoundFactory.Instance.Play(SoundFactory.Effects.Fireball);
        }

        public void SideCollisionResponse()
        {
            PhysicsObject.direction = !PhysicsObject.direction;
        }

        public void BounceOffGround()
        {
            PhysicsObject.dy = -10.0F;
            PhysicsObject.ySpeed = -10.0F;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            Sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle GetHitBox()
        {
            return Sprite.RetrieveSpriteRectangle();
        }

        public void Explode()
        {
            particles.Destroy();
            Game1.Instance.currentState.Level.RemoveFromLevel(this);
        }

        public void Update()
        {
            Sprite.Update();
            PhysicsObject.Update();
            Timer++;
            if (Timer > Lifetime)
            {
                particles.Destroy();
                Game1.Instance.currentState.Level.RemoveFromLevel(this);
                
            }
            if(Position.Y > 800)
            {
                particles.Destroy();
                Game1.Instance.currentState.Level.RemoveFromLevel(this);
                
            }
                
        }
    }
}
