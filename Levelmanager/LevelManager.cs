using Microsoft.Xna.Framework;
using SprintZero.FlagPoles;
using SprintZero.Exits;
using SprintZero.Items;
using SprintZero.Pipes;
using SprintZero.Player;
using SprintZero.Scenery;
using System;
using System.Xml;
using SprintZero.BlocksRefactored.ObstacleHitBox;
using SprintZero.Enemies.EnemyUtilities;

namespace SprintZero.Levelmanager
{
    public class LevelManager
    {
        private XmlReader LevelReader;
        private Level level;
        

        public LevelManager(string level)
        {
            LevelReader = XmlReader.Create(level);

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Level GetCurrentLevel()
        {
            return level;
        }

        public void LoadLevel()
        {
            level = new Level();
            LevelReader.MoveToContent();
            while (LevelReader.Read())
            {
                string type;
                string name;
                string location;
                if ((LevelReader.NodeType == XmlNodeType.Element) && (LevelReader.Name == "Item"))
                {
                    
                    LevelReader.ReadToDescendant("ObjectType");
                    type = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("ObjectName");
                    name = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("Location");
                    location = LevelReader.ReadElementContentAsString();
                    LoadObject(name, type, location);
                }
            }
        }
        private void LoadObject(string name, string type, string location)
        {
            location.Trim();
            string[] tokens = location.Split(new char[] {' '});
            int locationX = Convert.ToInt32(tokens[0]);
            int locationY = Convert.ToInt32(tokens[1]);

            switch (type)
            {
                case "Player":
                    MakePlayer(name, locationX, locationY);
                    break;
                case "Enemy":
                    EnemySpawner.Instance.AddEnemy(name, locationX, locationY);
                    break;
                case "Scenery":
                    MakeScenery(name, locationX, locationY);
                    break;
                case "Block":
                    MakeBlocks(name, locationX, locationY);
                    break;
                case "Item":
                    MakeItem(name, locationX, locationY);
                    break;
                case "Floor":
                    MakeFloor(name, locationX, locationY, Block.BlockType.Ground);
                    break;
                case "BlueFloor":
                    MakeFloor(name, locationX, locationY, Block.BlockType.BlueGround);
                    break;
                case "BlueBrickFloor":
                    MakeFloor(name, locationX, locationY, Block.BlockType.BlueBrick);
                    break;
                case "Exit":
                    MakeExit(name, locationX, locationY);
                    break;
                case "Column":
                    MakeColumn(name, locationX, locationY, Block.BlockType.Unbreakable);
                    break;
                case "BlueBrickColumn":
                    MakeColumn(name, locationX, locationY, Block.BlockType.BlueBrick);
                    break;
                case "PipeColumn":
                    MakePipeColumn(name, locationX, locationY);
                    break;
                default:
                    throw new InvalidOperationException("Game Object type: \"" + type + "\" doesn't exist.");
                
            }
        }

        private void MakeExit(string name,int locationX, int locationY)
        {
            switch (name)
            {
                    case "CastleExit":
                    level.AddExit(new CastleDoor(locationX, locationY));
                        break;
                    case "PipeExit":
                            //warp Pipe
                        break;
                    default:
                        throw new InvalidOperationException("Exit Object type: \"" + name + "\" doesn't exist.");
            }
        }

        private void MakeFloor(string length, int locationX, int locationY, Block.BlockType blockType)
        {
            Block.BlockType type = blockType;
            int floorX = locationX;
            int floorY = locationY;
            int floor2ndRowY = locationY + 32;
            int floorHeight = 32;
            int floorWidth = 0;
            int numOfFloorBlocks = Convert.ToInt32(length);
            int nextBlockStart = locationX;
            for (int i = 0; i < numOfFloorBlocks; i++)
            {
                level.individualFloorBlock.Add(new Block(nextBlockStart, locationY, type));
                level.individualFloorBlock.Add(new Block(nextBlockStart, floor2ndRowY, type));
                nextBlockStart += 32;
                floorWidth += 32;
            }
            level.BigFloorRectangles.Add(new ObstacleCombinedHitBox(floorX, floorY, floorWidth, floorHeight*2));
        }

        private void MakeColumn(string height, int locationX, int locationY, Block.BlockType blockType)
        {
            int numOfBlocksTall = Convert.ToInt32(height);
            int columnWidth = 32;
            int columnHeight = 32 * numOfBlocksTall;
            int nextBlockStartHeight = locationY;
            int columnYLocation = locationY - columnHeight + 32;
            for(int i = 0; i < numOfBlocksTall; i++)
            {
                level.individualFloorBlock.Add(new Block(locationX, nextBlockStartHeight, blockType));
                nextBlockStartHeight -= 32;
            }
            level.BigFloorRectangles.Add(new ObstacleCombinedHitBox(locationX, columnYLocation, columnWidth, columnHeight));
        }

        private void MakePipeColumn(string height, int locationX, int locationY)
        {
            int pipeHeight = Convert.ToInt32(height);
            int columnWidth = 56;
            int columnHeight = 32 * pipeHeight;
            int columnYLocation = locationY - columnHeight + 32;
            level.individualFloorBlock.Add(new PipeExtension(locationX, columnYLocation, pipeHeight));
            level.BigFloorRectangles.Add(new ObstacleCombinedHitBox(locationX, columnYLocation, columnWidth, columnHeight));
        }

        private void MakePlayer(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Mario":
                    level.Player =  new Mario(new Vector2(locationX, locationY));
                    break;
                default:
                    throw new InvalidOperationException("Player type: \"" + name + "\" doesn't exist");
            }
            
        }

        private void MakeScenery(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "BigHill":
                    level.AddBackGroundImage(new BigHillSprite(locationX, locationY));
                    break;
                case "SmallHill":
                    level.AddBackGroundImage(new SmallHillSprite(locationX, locationY));
                    break;
                case "Bush1":
                    level.AddBackGroundImage(new Bush1Sprite(locationX, locationY));
                    break;
                case "Bush2":
                    level.AddBackGroundImage(new Bush2Sprite(locationX, locationY));
                    break;
                case "Bush3":
                    level.AddBackGroundImage(new Bush3Sprite(locationX, locationY));
                    break;
                case "Cloud1":
                    level.AddBackGroundImage(new Cloud1Sprite(locationX, locationY));
                    break;
                case "Cloud2":
                    level.AddBackGroundImage(new Cloud2Sprite(locationX, locationY));
                    break;
                case "Cloud3":
                    level.AddBackGroundImage(new Cloud3Sprite(locationX, locationY));
                    break;
                case "Castle":
                    level.AddBackGroundImage(new CastleSprite(locationX, locationY));
                    break;
                default:
                    throw new InvalidOperationException("Scenery type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeBlocks(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "GroundBlock":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.Ground));
                    break;
                case "BreakableBlock":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.Brick));
                    break;
                case "BlueBrick":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.BlueBrick));
                    break;
                case "ItemBlockCoin":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.ItemCoin));
                    break;
                case "ItemBlockPowerUp":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.ItemPowerUp));
                    break;
                case "UnbreakableBlock":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.Unbreakable));
                    break;
                case "HiddenBlock":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.Hidden));
                    break;
                case "EmptyItemBlock":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.ItemUsed));
                    break;
                case "BrickCoin":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.BrickCoin));
                    break;
                case "BrickStar":
                    level.AddObject(new Block(locationX, locationY, Block.BlockType.BrickStar));
                    break;
                case "PipeS":
                    level.AddObject(new Pipe(locationX, locationY));
                    break;
                case "PipeM":
                    level.AddObject(new PipeMedium(locationX, locationY));
                    break;
                case "PipeL":
                    level.AddObject(new PipeLarge(locationX, locationY));
                    break;
                case "PipeLE":
                    level.AddObject(new PipeLargeEnterable(locationX, locationY));
                    break;
                case "TPipe":
                    level.AddObject(new TPipe(locationX, locationY));
                    break;
                case "SidewaysPipe":
                    level.AddObject(new SidewaysPipe(locationX, locationY));
                    break;
                case "FlagPole":
                    level.AddObject(new FlagPole(locationX, locationY));
                    break;
                default:
                    throw new InvalidOperationException("Block type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeItem(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Coin":
                    level.AddObject(new Coin(new Vector2(locationX, locationY)));
                    break;
                case "Flower":
                    level.AddObject(new FireFlower(new Vector2(locationX, locationY)));
                    break;
                case "RedShroom":
                    level.AddObject(new RedMushroom(new Vector2(locationX, locationY)));
                    break;
                case "GreenShroom":
                    level.AddObject(new GreenMushroom(new Vector2(locationX, locationY)));
                    break;
                case "Star":
                    level.AddObject(new Star(new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            }
        }
    }
}
