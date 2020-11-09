using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.MarioStatePattern;
using SprintZero.MarioStatePattern.MarioStates;
using SprintZero.ScreenCamera;
using SprintZero.Fireball;
using SprintZero.Levelmanager;
using SprintZero.GameStates;
using System.Collections.Generic;
using SprintZero.Decorator;
using SprintZero.Iceball;

namespace SprintZero.Player
{
    public class Mario : IMario, IGameObject
    {
        public IMarioState State { get; set; }
        public ISprite sprite { get; set; }
        public Vector2 Position { get; set; }
        public bool BigMario { get; set; }
        public bool FireMario { get; set; }
        public bool IceMario { get; set; }
        public IMarioPhysicsObject physicsObject { get; set; }
        public bool isJumping { get; set; }
        public bool isFalling { get; set; }
        public bool direction { get; set; }
        public bool onPipe { get; set; }
        public bool isCollidingWithFloor { get; set; }
        public int respawnTimer { get; set; }
        public int powerCooldown { get; set; }
        public int LocationX { get { return (int)Position.X; } set { Position = new Vector2(value, LocationY);}}
        public int LocationY { get { return (int)Position.Y; } set { Position = new Vector2(LocationX, value);}}
        public Stack<Past> history = new Stack<Past>();
        public int storedItemInt { get; set; }
        public bool hasStoredItem { get; set; }
        public struct Past
        {
            public Vector2 position;
            public IMarioState state;
            public ISprite sprite;
            public bool BigMario;
            public bool FireMario;
            public Past(Vector2 lastPos, IMarioState lastState, ISprite LastSprite, bool Big, bool Fire)
            {
                position = lastPos;
                state = lastState;
                sprite = LastSprite;
                BigMario = Big;
                FireMario = Fire;
            }
        }

        public Mario(Vector2 pos)
        {
            State = new RightSmallStandingMarioState(this);
            Position = pos;
            physicsObject = new MarioPhysicsObject(this);
            isJumping = false;
            isFalling = false;
            direction = true;
            respawnTimer = 0;
            hasStoredItem = false;
        }

        public void WalkLeft()
        {
            State.WalkLeft();
        }

        public void WalkRight()
        {
            State.WalkRight();
        }

        public void Sprint()
        {
            State.Sprint();
        }

        public void Jump()
        {
            if(!isFalling)
                State.Jump();
        }

        public void Fall()
        {
            State.Fall();
        }

        public void Land()
        {
            State.Land();
        }

        public void GetHit()
        {
            if(BigMario || FireMario)
            {
                SoundFactory.Instance.Play(SoundFactory.Effects.Pipe);
            }
            else
            {
                SoundFactory.Instance.Play(SoundFactory.Effects.Die);
            }
            State.GetHit();
            BigMario = false;
            FireMario = false;
        }

        public void Big()
        {
            State.Big();
            BigMario = true;
        }
    
        public void Die()
        {
            State.Die();
        }

        public void EnterPipe()
        {
            Game1.Instance.currentState = new PipeTransitionState();
        }

        public void Crouch()
        {
            State.Crouch();
            if (onPipe)
            {
                EnterPipe();
            }
        }

        public void Fire()
        {
            State.Fire();
            BigMario = true;
            FireMario = true;
        }

        public void Ice()
        {
            State.Ice();
            BigMario = true;
            IceMario = true;
        }

        public void UsePower()
        {
            if(FireMario && powerCooldown == 0)
            {
                powerCooldown = 30;
                Game1.Instance.currentState.Level.AddObject(new FireballObject(this.Position.X, this.Position.Y, direction));
            } else if(IceMario && powerCooldown == 0)
            {
                powerCooldown = 30;
                Game1.Instance.currentState.Level.AddObject(new IceballObject(this.Position.X, this.Position.Y, direction));
            }
        }

        public void UseStoredItem()
        {
            if (hasStoredItem)
            {
                switch (storedItemInt)
                {
                    case 1:
                        Fire();
                        break;
                    case 2:
                        Big();
                        break;
                    case 3:
                        Ice();
                        break;
                    default:
                        break;
                }
                hasStoredItem = false;
            }
        }

        public void Star()
        {
            State.Star();
        }

        public void Idle()
        {
            State.Idle();
        }
        public void Climb()
        {
            State.Climb();
        }

        public bool IsMarioDead()
        {
            if (State is DeadMarioState)
            {
                respawnTimer++;
                if (respawnTimer > 60)
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            sprite.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle RetrieveMarioRectangle()
        {
            return sprite.RetrieveSpriteRectangle();
        }

        public void Rewind()
        {
            physicsObject.ResetX();
            new RewindMario(this, history);
        }

        public void Unwind()
        {
        }

        public void Update()
        {
            Vector2 histPos = new Vector2(Position.X, Position.Y);
            history.Push(new Past(histPos, State, sprite, BigMario, FireMario));

            State.Update();
            sprite.Update();

            if (isFalling || isJumping)
            {
                onPipe = false;
            }

            PlayerOneCamera.Instance.SetView(Position);
            if(Position.Y > 920)
            {
                State.Die();
            }
        }
        
        public Rectangle GetHitBox()
        {
            return RetrieveMarioRectangle();
        }

        public void SideCollisionResponse()
        {
        }
    }
}
