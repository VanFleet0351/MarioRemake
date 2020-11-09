using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.ParticleEffects;
using SprintZero.Pipes;
using SprintZero.Player;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.Decorator
{
    class StarMario : IMario, IGameObject
    {
        public bool IceMario { get { return decoratedMario.IceMario; } set { decoratedMario.IceMario = value; } }
        public int storedItemInt { get { return decoratedMario.storedItemInt; } set { decoratedMario.storedItemInt = value; } }
        public bool hasStoredItem { get { return decoratedMario.hasStoredItem; } set { decoratedMario.hasStoredItem = value; } }
        public bool onPipe { get; set; }
        private IMario decoratedMario;
        private Game1 myGame;
        private int timer = 800;
        ParticleEngine Particles;

        private List<Color> colors = new List<Color> {
            Color.Aquamarine,
            Color.Wheat,
            Color.PaleVioletRed,
            Color.White
        };
        public Vector2 Position { get { return decoratedMario.Position; } set { decoratedMario.Position = value; } }
        public IMarioState State { get; set; }
        public ISprite sprite { get { return decoratedMario.sprite;} set { decoratedMario.sprite = value;} }
        public IMarioPhysicsObject physicsObject {get; set;}
        public bool BigMario { get {return decoratedMario.BigMario; } set { decoratedMario.BigMario = value; } }
        public bool FireMario { get { return decoratedMario.FireMario; } set { decoratedMario.FireMario = value; } }
        public bool isFalling { get { return decoratedMario.isFalling; } set { decoratedMario.isFalling = value; } }
        public bool isJumping { get { return decoratedMario.isJumping; } set { decoratedMario.isJumping = value; } }
        public bool isCollidingWithFloor { get { return decoratedMario.isCollidingWithFloor; } set { decoratedMario.isCollidingWithFloor = value; } }
        public bool direction { get { return decoratedMario.direction; } set { decoratedMario.direction = value; } }

        public StarMario(IMario decoratedMario, Game1 myGame)
        {
            this.decoratedMario = decoratedMario;
            this.myGame = myGame;
            physicsObject = decoratedMario.physicsObject;
            myGame.currentState.Level.Player = this;
            SoundFactory.Instance.StopSong();
            SoundFactory.Instance.Play(SoundFactory.ThemeSongs.Star);
            Collection<Texture2D> particleTexures = new Collection<Texture2D> { Game1.Instance.starSprite, Game1.Instance.diamondSprite, Game1.Instance.squareSprite };
            Particles = new ParticleEngine(particleTexures, this);
            Particles.SetIntensity(20);
        }

        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                RemoveStar();
            }
            decoratedMario.Update();
        }

        public void RemoveStar()
        {
            Particles.Destroy();
            myGame.currentState.Level.Player = (Mario)decoratedMario;
            SoundFactory.Instance.StopSong();
            if(Game1.Instance.stats.time < 100)
            {
                SoundFactory.Instance.Play(SoundFactory.ThemeSongs.Hurry);
            }
            else
            {
                SoundFactory.Instance.Play(SoundFactory.ThemeSongs.MainTheme);
            }
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

        public void Crouch()
        {
            decoratedMario.Crouch();
            if (onPipe)
            {
                EnterPipe();
            }
        }

        public void EnterPipe()
        {
            Game1.Instance.currentState = new PipeTransitionState();
        }

        public void Idle()
        {
            decoratedMario.Idle();
        }

        public void GetHit()
        {
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

        public void UseStoredItem()
        {
            decoratedMario.UseStoredItem();
        }

        public void Star()
        {
            timer = 1000;
        }

        public void Die()
        {
            decoratedMario.Die();
        }
        public void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color)
        {
            decoratedMario.Draw(spritebatch, spritesheet, colors[(timer / 7) % 4]);
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
            return RetrieveMarioRectangle();
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
            physicsObject.ResetX();
            Mario Player = (Mario)decoratedMario;
            new RewindMario(this, Player.history);
        }

        public void Unwind()
        {
            decoratedMario.Unwind();
        }
    }
}
