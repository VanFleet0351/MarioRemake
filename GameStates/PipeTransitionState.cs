
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Collision;
using SprintZero.Commands;
using SprintZero.Enemies;
using SprintZero.Enemies.EnemyUtilities;
using SprintZero.Interfaces;
using SprintZero.Items;
using SprintZero.Levelmanager;
using SprintZero.Pipes;
using SprintZero.ScreenCamera;
using System.Diagnostics;

namespace SprintZero.GameStates
{
    public class PipeTransitionState : AbstractGameState
    {
        public Texture2D allSpriteSheet { get; set; }
        public IMario mario { get; set; }
        public LevelManager levelManager { get; set; }
        private int frame { get; set; }
        public IPipe pipe { get; set; }



        public override void Initialize()
        {
            Controller = null;
            Level = Game1.Instance.currentState.Level;
            mario = Level.Player;
            SoundFactory.Instance.StopSong();
            SoundFactory.Instance.Play(SoundFactory.Effects.Pipe);
            frame = 0;
        }

        public override void LoadContent()
        {
            allSpriteSheet = content.Load<Texture2D>("Images/allSprites");
        }

        public override void Update()
        {
            if (frame < 30)
            {
                mario.Idle();
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 2);
            }
            else if (pipe is SidewaysPipe)
            {
                Game1.Instance.currentState = new LevelOneOneState();
                Game1.Instance.currentState.Level.Player = mario;
                Game1.Instance.currentState.Level.Player.Position = new Vector2(6016, 500);
            }
            else
            {
                Game1.Instance.savedState = Game1.Instance.currentState;
                Game1.Instance.currentState = new LevelOneOneUnderworldState();
                Game1.Instance.currentState.Level.Player = mario;
                Game1.Instance.currentState.Level.Player.Position = new Vector2(45, 0);
            }
            frame++;
        }

        public override void Reset()
        {
 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
