using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Decorator;
using SprintZero.Interfaces;
using SprintZero.Player;
using SprintZero.ScreenCamera;
using SprintZero.Sprites.EnemySprites;
using System.Collections;

namespace SprintZero.Enemies.GoombaStates
{
    public class LeftMovingGoombaState : AbstractGoombaState
    {

        public LeftMovingGoombaState(IEnemy goomba):base(goomba)
        {
            LocationMod = -1;
            Sprite = new MovingGoombaSprite(goomba);
        }

        public override void ChangeDirection()
        {
            Enemy.State = new RightMovingGoombaState(Enemy);
        }
    }
}
