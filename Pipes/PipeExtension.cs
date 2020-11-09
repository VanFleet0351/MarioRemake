using SprintZero.Sprites.PipeSprites;

namespace SprintZero.Pipes
{
    public class PipeExtension : AbstractPipe
    {
        public PipeExtension(int locationX, int locationY, int size) : base(locationX, locationY)
        {
            Sprite = new PipeExtensionSprite(this, size);
        }
    }
}
