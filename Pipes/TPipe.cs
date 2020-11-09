using SprintZero.Sprites.PipeSprites;

namespace SprintZero.Pipes
{
    public class TPipe : AbstractPipe
    {

        public TPipe(int locationX, int locationY) : base(locationX, locationY)
        {
            Sprite = new TPipeSprite(this);
        }
    }
}
