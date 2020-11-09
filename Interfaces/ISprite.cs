using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero
{
    public interface ISprite
    {
        void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color);
        Rectangle RetrieveSpriteRectangle();
        void Update();
    }
}
