using Microsoft.Xna.Framework.Graphics;
using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Levelmanager;
using SprintZero.ParticleEffects;
using SprintZero.Player;
using SprintZero.Sprites.EnemySprites;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.Enemies.KoopaStates
{
    class StompedKoopaState: AbstractKoopaState
    {
        private int regenTimer = 0;
        private readonly int regenLength = 400;
        private static int stompCount = 0;
        private ParticleEngine particle;

        public StompedKoopaState(IEnemy enemy):base(enemy)
        {
            Sprite = new StompedKoopaSprite(enemy);
            particle = new ParticleEngine(new Collection<Texture2D>(){ Game1.Instance.spiralSprite}, enemy);
            particle.SetColors(1, 1, 1, 1, 1, 1);
            particle.SetIntensity(1);
        }

        public override void BeFlipped()
        {
            particle.Destroy();
            Enemy.State = new FlippedKoopaState(Enemy);
        }

        public override void BeStomped()
        {
            particle.Destroy();
            base.BeStomped();
            if(stompCount == 0)
            {
                Game1.Instance.stats.AddScore(400, Enemy.Position);
                stompCount++;
            }
        }

        public override void Update()
        {
            regenTimer++;
            if(regenTimer > regenLength)
            {
                particle.Destroy();
                Enemy.State = new LeftMovingKoopaState(Enemy);
            }
            Sprite.Update();
        }
        public override void HitFromLeft(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                particle.Destroy();
                base.HitFromRight(hittingObject);
            }
            else
            {
                particle.Destroy();
                Enemy.State = new RightSlidingShellState(Enemy);
                Game1.Instance.stats.AddScore(500, Enemy.Position);
                SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
            }
        }

        public override void HitFromRight(IGameObject hittingObject)
        {
            if (!(hittingObject is Mario || hittingObject is ShrunkenMario))
            {
                particle.Destroy();
                base.HitFromRight(hittingObject);
            }
            else
            {
                particle.Destroy();
                Enemy.State = new LeftSlidingShellState(Enemy);
                Game1.Instance.stats.AddScore(500, Enemy.Position);
                SoundFactory.Instance.Play(SoundFactory.Effects.Kick);
            }
        }
    }
}
