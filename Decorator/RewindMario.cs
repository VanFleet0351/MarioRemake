using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Levelmanager;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using System.Collections.Generic;

namespace SprintZero.Decorator
{
    public class RewindMario: IMario
    {
        public bool onPipe { get; set; }
        private IMario decoratedMario;
        private Game1 myGame;

        public bool IceMario { get { return decoratedMario.IceMario; } set { decoratedMario.IceMario = value; } }
        public int storedItemInt { get { return decoratedMario.storedItemInt; } set { decoratedMario.storedItemInt = value; } }
        public bool hasStoredItem { get { return decoratedMario.hasStoredItem; } set { decoratedMario.hasStoredItem = value; } }

        public Vector2 Position { get { return decoratedMario.Position; } set { decoratedMario.Position = value; } }
        public IMarioState State { get; set; }
        public ISprite sprite { get; set; }
        public IMarioPhysicsObject physicsObject { get; set; }
        public bool BigMario { get { return decoratedMario.BigMario; } set { decoratedMario.BigMario = value; } }
        public bool FireMario { get { return decoratedMario.FireMario; } set { decoratedMario.FireMario = value; } }
        public bool isFalling { get { return decoratedMario.isFalling; } set { decoratedMario.isFalling = value; } }
        public bool isJumping { get { return decoratedMario.isJumping; } set { decoratedMario.isJumping = value; } }
        public bool isCollidingWithFloor { get { return decoratedMario.isCollidingWithFloor; } set { decoratedMario.isCollidingWithFloor = value; } }
        public bool direction { get { return decoratedMario.direction; } set { decoratedMario.direction = value; } }
        private Stack<Mario.Past> nextState;

        public RewindMario(IMario decoratedMario, Stack<Mario.Past> history)
        {
            nextState = history;
            this.decoratedMario = decoratedMario;
            myGame = Game1.Instance;
            physicsObject = decoratedMario.physicsObject;
            myGame.currentState.Level.Player = this;
            SoundFactory.Instance.StopSong();
            SoundFactory.Instance.Play(SoundFactory.ThemeSongs.timetravel);
        }

        public void Update()
        {
            if (nextState.Count > 0)
            {
                Mario.Past lastMario = nextState.Pop();
                RewindPowerUps(lastMario);
                decoratedMario.State = lastMario.state;
                decoratedMario.Position = lastMario.position;
                if (lastMario.sprite != decoratedMario.sprite)
                {
                    decoratedMario.sprite = lastMario.sprite;
                }
                decoratedMario.sprite.Update();
                decoratedMario.State.Update();
                PlayerOneCamera.Instance.RewindView(decoratedMario.Position);
            }
        }

        private void RewindPowerUps(Mario.Past lastMario)
        {
            if (BigMario && FireMario)
            {
                if (!lastMario.FireMario)
                {
                    ItemFactory.Instance.CreateFireFlower((int)decoratedMario.Position.X, (int)decoratedMario.Position.Y);
                    decoratedMario.FireMario = false;
                }
            }
            else if (BigMario && !FireMario)
            {
                if (!lastMario.BigMario)
                {
                    ItemFactory.Instance.CreateRedMushRoom((int)decoratedMario.Position.X, (int)decoratedMario.Position.Y);
                    decoratedMario.BigMario = false;
                }
            }
            else if (!BigMario && !FireMario)
            {
                if (lastMario.FireMario)
                {
                    decoratedMario.FireMario = true;
                    decoratedMario.BigMario = true;
                }
                else if (lastMario.BigMario)
                {
                    decoratedMario.BigMario = true;
                }
            }
        }

        public void RemoveStar()
        {
        }

        public void WalkLeft()
        {
        }

        public void WalkRight()
        {
        }

        public void Jump()
        {
        }
        public void Fall()
        {
        }

        public void Crouch()
        {
        }

        public void EnterPipe()
        {
        }

        public void Idle()
        {
        }

        public void GetHit()
        {
        }

        public void Big()
        {
        }

        public void Fire()
        {
        }

        public void Ice()
        {
        }

        public void UsePower()
        {
        }

        public void UseStoredItem()
        {
        }

        public void Die()
        {
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            decoratedMario.Draw(spritebatch, spritesheet, color);
        }

        public Rectangle RetrieveMarioRectangle()
        {
            return decoratedMario.RetrieveMarioRectangle();
        }

        public bool IsMarioDead()
        {
            return decoratedMario.IsMarioDead();
        }

        public Rectangle GetHitBox()
        {
            return RetrieveMarioRectangle();
        }

        public void SideCollisionResponse()
        {
        }

        public void Land()
        {
        }

        public void Sprint()
        {
        }

        public void Climb()
        {
        }

        public void Rewind()
        {
        }

        public void Unwind()
        {
            myGame.currentState.Level.Player = decoratedMario;
            if(decoratedMario is StarMario)
            {
                SoundFactory.Instance.Play(SoundFactory.ThemeSongs.Star);
            }
            else
            {
                SoundFactory.Instance.Play(SoundFactory.ThemeSongs.MainTheme);
            }
            decoratedMario.physicsObject.ResetX();
            decoratedMario.physicsObject.ResetY();
            decoratedMario.Idle();
        }

        public void Star()
        {
        }
    }
}
