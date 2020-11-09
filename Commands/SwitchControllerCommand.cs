using SprintZero.Controllers;
using SprintZero.Interfaces;

namespace SprintZero.Commands
{
    public class SwitchControllerCommand : ICommand
    {
        public void Execute()
        {
            if(Game1.Instance.currentState.Controller is KeyboardController)
            {
                Game1.Instance.currentState.Controller = new GamePadController();
            }
            else
            {
                Game1.Instance.currentState.Controller = new KeyboardController(Game1.Instance);
            }
        }
    }
}
