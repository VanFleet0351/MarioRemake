using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.BlocksRefactored.BlockStates;
using SprintZero.FlagPoles.BlockStates;
using SprintZero.Interfaces;

namespace SprintZero.FlagPoles
{
    class Block : IBlock
    {
        public IBlockState State { get; set; }
        public Vector2 Position { get; set; }
        public bool WasHit { get { return State.WasHit;} set { State.WasHit = value; } }
        public enum BlockType {Brick, BrickCoin, BrickStar, ItemCoin, ItemPowerUp, Hidden, ItemUsed, Ground, Unbreakable , BlueGround, BlueBrick}

        public Block(int locationX, int locationY, BlockType type)
        {
            Position = new Vector2(locationX, locationY);
            ChangeState(type);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            State.Draw(spriteBatch, spriteSheet, color);
        }

        public Rectangle GetHitBox()
        {
            return State.ReturnObjectRectangle();
        }

        public void Update()
        {
            State.Update();
        }

        private void ChangeState(BlockType type)
        {
            switch(type)
            {
                case BlockType.Brick:
                    State = new BrickBlockState(this);
                    break;
                case BlockType.BrickCoin:
                    State = new BrickCoinState(this);
                    break;
                case BlockType.BrickStar:
                    State = new BrickStarState(this);
                    break;
                case BlockType.ItemCoin:
                    State = new ItemBlockCoinState(this);
                    break;
                case BlockType.ItemPowerUp:
                    State = new ItemBlockPowerUpState(this);
                    break;
                case BlockType.Hidden:
                    State = new HiddenItemBlockState(this);
                    break;
                case BlockType.ItemUsed:
                    State = new ItemBlockUsedState(this);
                    break;
                case BlockType.Ground:
                    State = new GroundBlockState(this);
                    break;
                case BlockType.Unbreakable:
                    State = new UnbreakableBlockState(this);
                    break;
                case BlockType.BlueBrick:
                    State = new BlueBrickState(this);
                    break;
                case BlockType.BlueGround:
                    State = new BlueGroundState(this);
                    break;
            }
        }

        public void BeHit()
        {
            State.BeHit();
        }

        public void BeBumped()
        {
            State.BeBumped();
        }

        public void SideCollisionResponse()
        {

        }
    }
}
