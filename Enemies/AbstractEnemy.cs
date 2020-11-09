using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;

namespace SprintZero.Enemies
{
    public abstract class AbstractEnemy: IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public bool IsFalling { get; set; }
        public bool IsFrozen { get; set; }
        private int FrozenTimer;
        public IEnemyPhysicsObject PhysicsObject { get; set; }

        protected AbstractEnemy(Vector2 location)
        {
            Position = location;
            PhysicsObject = new EnemyPhysicsObject(this);
        }

        public void SideCollisionResponse()
        {
            if(!IsFrozen)
                State.ChangeDirection();
        }

        public void BeStomped()
        {
            State.BeStomped();
            SoundFactory.Instance.Play(SoundFactory.Effects.Stomp);
        }

        public void BeFlipped()
        {
            State.BeFlipped();
        }

        public void Fall()
        {
            PhysicsObject.Fall();
        }

        public void Freeze()
        {
            IsFrozen = true;
        }

        public Rectangle GetHitBox()
        {
            return State.GetHitBox();
        }

        public void Update()
        {
            if (!IsFrozen)
            {
                if (IsFalling)
                    Fall();
                else
                    PhysicsObject.Reset(true);
            }

            if(Position.Y > 800)
            {
                Game1.Instance.currentState.Level.RemoveFromLevel(this);
            }

            if(!IsFrozen)
                State.Update();

            FrozenTimer++;
            if(FrozenTimer > 300)
            {
                FrozenTimer = 0;
                IsFrozen = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            if (IsFrozen)
                color = Color.Blue;

            State.Draw(spriteBatch, spriteSheet, color);
        }

        public void HitFromLeft(IGameObject hittingObject)
        {
            State.HitFromLeft(hittingObject);
        }

        public void HitFromRight(IGameObject hittingObject)
        {
            State.HitFromRight(hittingObject);
        }
    }
}
