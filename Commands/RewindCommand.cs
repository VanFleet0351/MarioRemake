using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    public class RewindCommand: ICommand
    {
        public void Execute()
        {
            Game1.Instance.currentState.Level.Player.Rewind();
        }
    }
}
