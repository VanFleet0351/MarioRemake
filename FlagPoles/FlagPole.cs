using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.Sprites.ScenerySprites;

namespace SprintZero.FlagPoles
{
    public class FlagPole: IGameObject
    {

        private ISprite poleSprite;
        private ISprite Flag;
        public Vector2 Position { get; set; }
        private bool poleHit = false;
        private bool pointsAwarded = false;

        public FlagPole(int locationX, int locationY)
        {
            Position = new Vector2(locationX, locationY);
            poleSprite = new FlagPoleSprite(locationX, locationY);
            Flag = new FlagSprite(this);
        }

        public void SideCollisionResponse()
        {
            poleHit = true;
        }

        public void GivePoints(int height)
        {
            int points = 0;
            if (height < 384)
            {
                points = 5000;
            }
            else if (height < 444)
            {
                points = 4000;
            }
            else if(height < 504)
            {
                points = 800;
            }
            else if(height < 564)
            {
                points = 400;
            }
            else
            {
                points = 100;
            }
            if (!pointsAwarded)
            {
                Game1.Instance.stats.AddScore(points, Position);
                pointsAwarded = true;
                SoundFactory.Instance.Play(SoundFactory.Effects.FlagPole);
                Game1.Instance.currentState = new EndOfLevelState();
            }

            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            poleSprite.Draw(spriteBatch, spriteSheet, color);
            Flag.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle GetHitBox()
        {
            return poleSprite.RetrieveSpriteRectangle();
        }

        public void Update()
        {
            if (poleHit && Position.Y <= 592)
            {
                Position = new Vector2(Position.X, Position.Y + 2);
            }
            Flag.Update();
        }
    }
}
