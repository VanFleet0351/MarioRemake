using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Sprites.ExitSprites;

namespace SprintZero.Exits
{
    public class CastleDoor: IExit
    {
        public int LocationX { get; }
        public int LocationY { get; }
        private readonly ISprite sprite;

        public CastleDoor(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            sprite = new CastleDoorSprite(LocationX, LocationY);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            sprite.Draw(spriteBatch, spriteSheet, color);
        }
    }
}
