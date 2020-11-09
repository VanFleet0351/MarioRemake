
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Collision;
using SprintZero.Commands;
using SprintZero.Enemies;
using SprintZero.Enemies.EnemyUtilities;
using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Levelmanager;
using SprintZero.ScreenCamera;

namespace SprintZero.GameStates
{
    public class EndOfLevelState : AbstractGameState
    {
        public Texture2D allSpriteSheet { get; set; }
        public IMario mario { get; set; }
        private CollisionDetection collisionHandler { get; set; }
        public LevelManager levelManager { get; set; }
        private int frame { get; set; }
        private ICommand RightCommand = new RightCommand(Game1.Instance);
        bool soundPlayed = false;

        public override void Initialize()
        {
            Controller = null;
            Level = Game1.Instance.currentState.Level;
            mario = Level.Player;
            collisionHandler = new CollisionDetection(Level);
            SoundFactory.Instance.StopSong();
            frame = 0;
        }

        public override void LoadContent()
        {
            allSpriteSheet = content.Load<Texture2D>("Images/allSprites");
        }

        public override void Update()
        {
            mario.Update();
            Level.Update();
            collisionHandler.DetectCollision(Level.Player);
            PlayerOneCamera.Instance.Update();

            if (frame < 140)
            {
                mario.Climb();
            }
            else if (frame > 140 && frame < 400)
            {
                RightCommand.Execute();
                if (!soundPlayed) {
                    mario.physicsObject.dt = 0.1F;
                    SoundFactory.Instance.Play(SoundFactory.Effects.EndLevel);
                    soundPlayed = true;
                }
            }
            else
            {
                mario.Idle();
                mario.physicsObject.dx = 0;
                mario.physicsObject.runSpeed = 0;
            }

            if (frame > 520)
                Game1.Instance.currentState = new Level2State();

            frame++;
        }

        public override void Reset()
        {
            EnemySpawner.Instance.Reset();
            Initialize();
            base.Reset();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(new Color(0.39f, 0.58f, 0.95f));
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, PlayerOneCamera.Instance.View);
            Level.Draw(spriteBatch, allSpriteSheet, Color.White);
            spriteBatch.End();
        }
    }
}
