using SprintZero.Sprites.PipeSprites;

namespace SprintZero.Pipes
{
    public class Pipe: AbstractPipe
    {

        public Pipe(int locationX, int locationY):base(locationX, locationY)
        {
            Sprite = new PipeSprite(this);
        }
    }
}

