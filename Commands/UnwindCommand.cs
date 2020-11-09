using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    public class UnwindCommand : ICommand
    {
        public void Execute()
        {
            Game1.Instance.currentState.Level.Player.Unwind();
        }
    }
}
