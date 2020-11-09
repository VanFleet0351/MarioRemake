using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SprintZero.Levelmanager
{
    public class SoundFactory
    {
        private static SoundFactory instance;
        private Song mainTheme, undergroundTheme, starTheme, hurryTheme, gameOverTheme, timetravel;
        private SoundEffect jump, longJump, powerUp, powerUpAppears, pause, fireball, coin, bump, breakBlock, oneUp, kick, stomp, flagPole, die, pipe, endLevel;
        private ContentManager content;

        public enum ThemeSongs { MainTheme, Underground, Star, Hurry, GameOver, timetravel}
        public enum Effects { Jump, LongJump, PowerUp, PowerUpAppear, Pause, Fireball, Coin, Bump, BreakBlock, OneUp, Kick, Stomp, Die, FlagPole, Pipe, EndLevel}

        public static SoundFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SoundFactory();
                }
                return instance;
            }
        }


        private SoundFactory()
        {
            content = Game1.Instance.Content;
            mainTheme = content.Load<Song>("Themes/mainTheme");
            starTheme = content.Load<Song>("Themes/starman");
            hurryTheme = content.Load<Song>("Themes/hurryTheme");
            gameOverTheme = content.Load<Song>("Themes/gameover");
            timetravel = content.Load<Song>("Themes/time-travel");
            undergroundTheme = content.Load<Song>("Themes/underworld");
            endLevel = content.Load<SoundEffect>("SFX/smb_stage_clear");
            jump = content.Load<SoundEffect>("SFX/jumpsmall");
            longJump = content.Load<SoundEffect>("SFX/jumpsuper");
            powerUp = content.Load<SoundEffect>("SFX/powerup");
            powerUpAppears = content.Load<SoundEffect>("SFX/powerup_appears");
            pause = content.Load<SoundEffect>("SFX/pause");
            fireball = content.Load<SoundEffect>("SFX/fireball");
            coin = content.Load<SoundEffect>("SFX/coin");
            bump = content.Load<SoundEffect>("SFX/bump");
            breakBlock = content.Load<SoundEffect>("SFX/breakblock");
            oneUp = content.Load<SoundEffect>("SFX/1-up");
            kick = content.Load<SoundEffect>("SFX/kick");
            stomp = content.Load<SoundEffect>("SFX/stomp");
            die = content.Load<SoundEffect>("SFX/mariodie");
            pipe = content.Load<SoundEffect>("SFX/pipe");
            stomp = content.Load<SoundEffect>("SFX/stomp");
            flagPole = content.Load<SoundEffect>("SFX/flagpole");
            MediaPlayer.IsRepeating = true;
        }

        public void Play(ThemeSongs song)
        {
            switch (song)
            {
                case ThemeSongs.MainTheme:
                    MediaPlayer.Play(mainTheme);
                    break;
                case ThemeSongs.Star:
                    MediaPlayer.Play(starTheme);
                    break;
                case ThemeSongs.Hurry:
                    MediaPlayer.Play(hurryTheme);
                    break;
                case ThemeSongs.GameOver:
                    MediaPlayer.Play(gameOverTheme);
                    break;
                case ThemeSongs.Underground:
                    MediaPlayer.Play(undergroundTheme);
                    break;
                case ThemeSongs.timetravel:
                    MediaPlayer.Play(timetravel);
                    break;
            }
        }

        public void Play(Effects soundEffect)
        {
            switch (soundEffect)
            {
                case Effects.Jump:
                    jump.Play(0.9f,0,0);
                    break;
                case Effects.LongJump:
                    longJump.Play();
                    break;
                case Effects.PowerUp:
                    powerUp.Play();
                    break;
                case Effects.PowerUpAppear:
                    powerUpAppears.Play();
                    break;
                case Effects.Pause:
                    pause.Play();
                    break;
                case Effects.Fireball:
                    fireball.Play();
                    break;
                case Effects.Coin:
                    coin.Play();
                    break;
                case Effects.Bump:
                    bump.Play();
                    break;
                case Effects.BreakBlock:
                    breakBlock.Play();
                    break;
                case Effects.OneUp:
                    oneUp.Play();
                    break;
                case Effects.Kick:
                    kick.Play();
                    break;
                case Effects.Stomp:
                    stomp.Play();
                    break;
                case Effects.Die:
                    die.Play();
                    break;
                case Effects.Pipe:
                    pipe.Play();
                    break;
                case Effects.FlagPole:
                    flagPole.Play();
                    break;
                case Effects.EndLevel:
                    endLevel.Play();
                    break;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void pauseSong()
        {
            MediaPlayer.Pause();
        }

        public void resumeSong()
        {
            MediaPlayer.Resume();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void StopSong()
        {
            MediaPlayer.Stop();
        }
    }
}
