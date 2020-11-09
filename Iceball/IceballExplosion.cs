using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ItemSprites;
using System;

namespace SprintZero.Iceball
{
    public class IceballExplosion : IGameObject
    {
        public Vector2 Position { get; set; }
        private ISprite Sprite;
        private int currentFrame = 0;
        private readonly int cycleLength = 15;

        public IceballExplosion(int locationX, int locationY)
        {
            Position = new Vector2(locationX, locationY);
            Sprite = new IceballExplosionSprite(this);
            SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            Sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
            {
                Game1.Instance.currentState.Level.RemoveFromLevel(this);
            }
            Sprite.Update();
        }

        public Rectangle GetHitBox()
        {
            return Sprite.RetrieveSpriteRectangle();
        }

        public void SideCollisionResponse()
        {
            throw new NotImplementedException();
        }
        

        
    }
}
