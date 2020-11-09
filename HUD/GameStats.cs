using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.ScreenCamera;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.HUD
{
    public class GameStats
    {

        public int coins { get; set; }
        public int lives { get; set; }
        public int score { get; set; }
        public int time { get; set; }
        public int resetTime { get; set; }
        public string level { get; set; }
        public SpriteFont font { get; set; }
        public int screenLeftEdge { get; set; }
        private Texture2D coinSprite { get; set; }

        private int cycleLength { get; set; }
        private int frame { get; set; }
        private bool endTimes = false;
        public IMario mario { get; set; }
        private Collection<FloatingStat> screenStats = new Collection<FloatingStat>();
        private Collection<FloatingStat> removeStats = new Collection<FloatingStat>();
        private Collection<Rectangle> coinSource = new Collection<Rectangle>
        {
            new Rectangle(463, 164, 5, 8),
            new Rectangle(470, 164, 5, 8),
            new Rectangle(477, 164, 5, 8)
        };

        public GameStats()
        {
            frame = 0;
            cycleLength = 50;
            coinSprite = Game1.Instance.Content.Load<Texture2D>("Images/allSprites");
            coins = 0;
            lives = 3;
            score = 0;
            time = 400;
            resetTime = 0;
            font = Game1.Instance.Content.Load<SpriteFont>("font");
            screenLeftEdge = 0;
            level = "1-1";
        }

        public void AddCoin()
        {
            coins++;
        }

        public void AddScore(int points)
        {
            score += points;
        }

        public void AddScore(int points, Vector2 position)
        {
            score += points;
            Vector2 adjustedPosition = new Vector2(position.X - PlayerOneCamera.Instance.LeftBound, position.Y);
            screenStats.Add(new FloatingStat(points.ToString(), adjustedPosition));
        }

        public void RemoveStat(FloatingStat stat)
        {
            removeStats.Add(stat);
        }

        public void AddLives()
        {
            lives++;
        }

        public void AddLives(Vector2 position)
        {
            lives++;
            Vector2 adjustedPosition = new Vector2(position.X - PlayerOneCamera.Instance.LeftBound, position.Y);
            screenStats.Add(new FloatingStat("1UP", adjustedPosition));
        }

        public void Reset()
        {
            resetTime = (int)Game1.Instance.gameTime.TotalGameTime.TotalSeconds;
        }

        public void Update()
        {
            screenLeftEdge = PlayerOneCamera.Instance.LeftBound;
            frame = (frame + 1) % cycleLength;
            if(!(Game1.Instance.currentState is PauseState))
                time = 400 - ((int)Game1.Instance.gameTime.TotalGameTime.TotalSeconds - resetTime);

            if(time <= 100 && !endTimes)
            {
                SoundFactory.Instance.StopSong();
                SoundFactory.Instance.Play(SoundFactory.ThemeSongs.Hurry);
                endTimes = true;
            }
            foreach(FloatingStat rStat in removeStats)
            {
                screenStats.Remove(rStat);
            }
            removeStats.Clear();
            foreach(FloatingStat stat in screenStats)
            {
                stat.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle coinDestination = new Rectangle(256, 40, 15, 24);
            Rectangle storedItemDestination = new Rectangle(400, 40, 15, 24);
            Rectangle fireFlowerDestination = new Rectangle(109, 64, 16, 16);
            Rectangle iceFlowerDestination = new Rectangle(52, 64, 16, 16);
            Rectangle redMushroomDestination = new Rectangle(71, 43, 16, 16);
            spriteBatch.DrawString(font, "Mario", new Vector2(20, 10), Color.White, 0, new Vector2(0,0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, score.ToString().PadLeft(6,'0'), new Vector2(10, 40), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.Draw(coinSprite, coinDestination, coinSource[3 * frame / cycleLength], Color.White);
            spriteBatch.DrawString(font, "x" + coins.ToString().PadLeft(2,'0'), new Vector2(280, 35), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "World" , new Vector2(700, 10), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "1-1", new Vector2(720, 40), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Time", new Vector2(950, 10), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, time.ToString().PadLeft(3, '0'), new Vector2(955, 40), Color.White, 0, new Vector2(0, 0), 1.8f, SpriteEffects.None, 0);
            try
            {
                mario = Game1.Instance.currentState.Level.Player;
                if (mario.hasStoredItem)
                {
                    if (mario.storedItemInt == 1)
                    {
                        spriteBatch.Draw(coinSprite, storedItemDestination, fireFlowerDestination, Color.White);
                    }
                    else if (mario.storedItemInt == 2)
                    {
                        spriteBatch.Draw(coinSprite, storedItemDestination, redMushroomDestination, Color.White);
                    }
                    else if (mario.storedItemInt == 3)
                    {
                        spriteBatch.Draw(coinSprite, storedItemDestination, iceFlowerDestination, Color.Blue);
                    }
                }
            }
            catch
            {
            }
            foreach (FloatingStat stat in screenStats)
            {
                stat.Draw(spriteBatch, font);
            }
        }
    }
}
