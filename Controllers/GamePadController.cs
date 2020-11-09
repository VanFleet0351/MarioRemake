using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZero.Commands;
using SprintZero.Interfaces;


namespace SprintZero.Controllers
{
    public class GamePadController : IController
    {

        GamePadState gamePadState;

        public GamePadController()
        {
        }

        public void Update()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);
            ICommand command;
            ICommand idleCommand = new IdleMarioCommand(Game1.Instance);

            if (gamePadState.IsButtonDown(Buttons.A) || gamePadState.IsButtonDown(Buttons.B) || gamePadState.IsButtonDown(Buttons.DPadLeft) || gamePadState.IsButtonDown(Buttons.DPadRight) ||
                gamePadState.IsButtonDown(Buttons.DPadUp) || gamePadState.IsButtonDown(Buttons.DPadDown) || gamePadState.ThumbSticks.Left.X > 0.5f || gamePadState.ThumbSticks.Left.X < -0.5f ||
                gamePadState.ThumbSticks.Left.Y > 0.5f || gamePadState.ThumbSticks.Left.X < -0.5f || gamePadState.IsButtonDown(Buttons.Back) || gamePadState.IsButtonDown(Buttons.Start))
            {
                if (gamePadState.IsButtonDown(Buttons.A))
                {
                    command = new UpCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.B))
                {
                    command = new FireBallCommand(Game1.Instance);
                    command.Execute();
                    command = new SprintCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.DPadLeft))
                {
                    command = new LeftCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.DPadRight))
                {
                    command = new RightCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.DPadUp))
                {
                    command = new UpCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.DPadDown))
                {
                    command = new DownCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.ThumbSticks.Left.X > 0.5f)
                {
                    command = new RightCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.ThumbSticks.Left.X < -0.5f)
                {
                    command = new LeftCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.ThumbSticks.Left.Y > 0.5f)
                {
                    command = new UpCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.ThumbSticks.Left.X < -0.5f)
                {
                    command = new DownCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.Back))
                {
                    command = new ExitCommand(Game1.Instance);
                    command.Execute();
                }
                if (gamePadState.IsButtonDown(Buttons.Start))
                {
                    command = new SwitchControllerCommand();
                    command.Execute();
                }
                if(!gamePadState.IsButtonDown(Buttons.DPadLeft) && !gamePadState.IsButtonDown(Buttons.DPadRight))
                {
                    command = new IdleMarioCommand(Game1.Instance);
                    command.Execute();
                }
            }
            else
            {
                idleCommand.Execute();
            }
        }
    }
}
