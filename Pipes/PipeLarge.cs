using SprintZero.Sprites.PipeSprites;

namespace SprintZero.Pipes
{
    public class PipeLarge: AbstractPipe
    {
        public PipeLarge(int locationX, int locationY) : base(locationX, locationY)
        {
            Sprite = new PipeLargeSprite(this);
        }
    }
}
