using SprintZero.Sprites.PipeSprites;

namespace SprintZero.Pipes
{
    public class PipeMedium: AbstractPipe
    {
        public PipeMedium(int locationX, int locationY):base(locationX, locationY)
        {
            Sprite = new PipeMediumSprite(this);
        }
    }
}
