using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZero.Commands;
using SprintZero.Controllers;
using SprintZero.GameStates;
using SprintZero.Interfaces;
using System;
using System.Collections.Generic;

namespace SprintZero
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Game1 myGame;
        private bool fireBallShot = false;
        private List<Keys> previousKeys = new List<Keys>();

        public KeyboardController(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand();
        }

        private void RegisterCommand()
        {
            controllerMappings.Add(Keys.W, new UpCommand(myGame));
            controllerMappings.Add(Keys.Up, new UpCommand(myGame));
            controllerMappings.Add(Keys.A, new LeftCommand(myGame));
            controllerMappings.Add(Keys.Left, new LeftCommand(myGame));
            controllerMappings.Add(Keys.S, new DownCommand(myGame));
            controllerMappings.Add(Keys.Down, new DownCommand(myGame));
            controllerMappings.Add(Keys.D, new RightCommand(myGame));
            controllerMappings.Add(Keys.Right, new RightCommand(myGame));
            controllerMappings.Add(Keys.X, new SprintCommand(myGame));
            controllerMappings.Add(Keys.Z, new FireBallCommand(myGame));
            controllerMappings.Add(Keys.RightShift, new FireBallCommand(myGame));
            controllerMappings.Add(Keys.Y, new SmallMarioCommand(myGame));
            controllerMappings.Add(Keys.U, new BigMarioCommand(myGame));
            controllerMappings.Add(Keys.I, new FireMarioCommand(myGame));
            controllerMappings.Add(Keys.K, new IceMarioCommand(myGame));
            controllerMappings.Add(Keys.T, new UseStoredItemCommand(myGame));
            controllerMappings.Add(Keys.Q, new ExitCommand(myGame));
            controllerMappings.Add(Keys.R, new ResetCommand(myGame));
            controllerMappings.Add(Keys.O, new MarioDieCommand(myGame));
            controllerMappings.Add(Keys.None, new IdleMarioCommand(myGame));
            controllerMappings.Add(Keys.Back, new PauseCommand(myGame));
            controllerMappings.Add(Keys.Enter, new StartGameCommand(myGame));
            controllerMappings.Add(Keys.LeftControl, new SwitchControllerCommand());
            controllerMappings.Add(Keys.RightControl, new SwitchControllerCommand());
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if (myGame.currentState is PauseState)
            {
                if (Array.IndexOf(pressedKeys, Keys.Back) != -1 && previousKeys.Contains(Keys.Back))
                    return;

                if (Array.IndexOf(pressedKeys, Keys.Back) == -1)
                    previousKeys.Clear();

                if (Array.IndexOf(pressedKeys, Keys.Back) != -1)
                {
                    controllerMappings[Keys.Back].Execute();
                    previousKeys.Add(Keys.Back);
                }
            }
            else if (myGame.currentState is MainMenuState)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (key == Keys.Enter)
                        controllerMappings[Keys.Enter].Execute();
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyUp(Keys.Z) && Keyboard.GetState().IsKeyUp(Keys.RightShift))
                {
                    fireBallShot = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                {
                    new RewindCommand().Execute();
                }
                else
                {
                    new UnwindCommand().Execute();
                }
                
                if (pressedKeys.Length == 0)
                {
                    controllerMappings[Keys.None].Execute();
                    previousKeys.Clear();
                    return;
                }
                else if ((Array.IndexOf(pressedKeys, Keys.Left) == -1 && Array.IndexOf(pressedKeys, Keys.Right) == -1) &&
                         (previousKeys.Contains(Keys.Left) || previousKeys.Contains(Keys.Right)))
                {
                    controllerMappings[Keys.None].Execute();
                }

                if (Array.IndexOf(pressedKeys, Keys.Back) >= 0 && (previousKeys.Contains(Keys.Back) || previousKeys.Contains(Keys.F1)))
                {
                    int i = Array.IndexOf(pressedKeys, Keys.Back);
                    pressedKeys[i] = Keys.F1;
                }

                previousKeys.Clear();
                Comparison<Keys> comparison = new Comparison<Keys>(CompareAlphabet);
                Array.Sort(pressedKeys, comparison);
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        if (key == Keys.Z || key == Keys.RightShift)
                        {
                            if (!fireBallShot)
                            {
                                controllerMappings[key].Execute();
                            }
                            fireBallShot = true;
                        }
                        else
                        {
                            controllerMappings[key].Execute();
                        }
                    }
                    previousKeys.Add(key);
                }
            }
        }

        public int CompareAlphabet(Keys a, Keys b)
        {
            String x = a.ToString();
            String y = b.ToString();

            return x.CompareTo(y);
        }
    }
}