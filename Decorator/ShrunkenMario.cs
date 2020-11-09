using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Pipes;
using SprintZero.Player;
using System.Collections.Generic;

namespace SprintZero.Decorator
{
    class ShrunkenMario : IMario, IGameObject
    {
        public bool onPipe { get; set; }
        public bool IceMario { get { return decoratedMario.IceMario; } set { decoratedMario.IceMario = value; } }
        public int storedItemInt { get { return decoratedMario.storedItemInt; } set { decoratedMario.storedItemInt = value; } }
        public bool hasStoredItem { get { return decoratedMario.hasStoredItem; } set { decoratedMario.hasStoredItem = value; } }
        private IMario decoratedMario;
        private Game1 myGame;
        private int timer = 150;
        
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

        private List<Color> colors = new List<Color> {
            Color.Transparent,
            Color.White
        };

        public ShrunkenMario(IMario decoratedMario, Game1 myGame)
        {
            this.decoratedMario = decoratedMario;
            this.myGame = myGame;
            physicsObject = decoratedMario.physicsObject;
            myGame.currentState.Level.Player = this;
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveInvincibilityFrames();
            }
            decoratedMario.Update();
        }

        public void RemoveInvincibilityFrames()
        {
            myGame.currentState.Level.Player = decoratedMario;
        }

        public void WalkLeft()
        {
            decoratedMario.WalkLeft();
        }

        public void WalkRight()
        {
            decoratedMario.WalkRight();
        }

        public void Jump()
        {
            decoratedMario.Jump();
        }
        public void Fall()
        {
            decoratedMario.Fall();
        }

        public void EnterPipe()
        {
            Game1.Instance.currentState = new PipeTransitionState();
        }

        public void Crouch()
        {
            decoratedMario.Crouch();
            if (onPipe)
            {
                EnterPipe();
            }
        }

        public void Idle()
        {
            decoratedMario.Idle();
        }

        public void GetHit()
        {
        }
public void UseStoredItem()
        {
            decoratedMario.UseStoredItem();
        }
        public void Big()
        {
            decoratedMario.Big();
        }

        public void Fire()
        {
            decoratedMario.Fire();
        }
        public void Ice()
        {
            decoratedMario.Ice();
        }
        public void UsePower()
        {
            decoratedMario.UsePower();
        }

        

        public void Star()
        {
            decoratedMario.Star();
        }

        public void Die()
        {
            decoratedMario.Die();
        }

        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            decoratedMario.Draw(spritebatch, spritesheet, colors[(timer / 3) % 2]);
        }

        public Rectangle RetrieveMarioRectangle()
        {
            return decoratedMario.RetrieveMarioRectangle();
        }

        public bool IsMarioDead()
        {
            return decoratedMario.IsMarioDead();
        }

        //will go after refactor
        public Rectangle GetHitBox()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public void SideCollisionResponse()
        {
            //will go after refactor
        }

        public void Land()
        {
            decoratedMario.Land();
        }

        public void Sprint()
        {
            decoratedMario.Sprint();
        }
        public void Climb()
        {
            decoratedMario.Climb();
        }

        public void Rewind()
        {
            decoratedMario.Rewind();
        }

        public void Unwind()
        {
            decoratedMario.Unwind();
        }
    }
}
