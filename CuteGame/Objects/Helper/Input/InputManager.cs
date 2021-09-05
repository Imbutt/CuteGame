using CuteGame.Objects.Helper.Input.InputClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper
{ 
    public class InputManager
    {
        public SpyGame Game { get; private set; }

        public KeyboardState keyboardState;
        public KeyboardState oldKeyboardState;
        public MouseState mouseState;
        public MouseState oldMouseState;

        public InputManager(SpyGame game)
        {
            this.Game = game;
        }

        // KEYS STRUCTS

        public enum MOUSEBUTTON
        {
            RIGHT,
            LEFT,
            MIDDLE
        }

        public enum STATE
        {
            NEW,
            OLD
        }

        public void UpdateInputStates()
        {
            oldKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();   // Update keyboard state
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public string GetInputClassJson(Type type)
        {
            object inputClass = Activator.CreateInstance(type);
            return JsonConvert.SerializeObject(inputClass);
        }

        public bool IsKeybKeyDown(Keys key)
        {
            if (this.keyboardState.IsKeyDown(key))
                return true;
            else
                return false;
        }
        
        public bool IsKeybKeyPressed(Keys key)
        {
            if (this.keyboardState.IsKeyDown(key) && !this.oldKeyboardState.IsKeyDown(key))
                return true;
            else
                return false;
        }

        // Mouse buttons

        /// <summary>
        /// Get the button state based on the enum and mousestate
        /// </summary>
        /// <param name="buttonEnum"> enum to identify button </param>
        /// <param name="mouseState"> what mousestate to get the buttonstate from </param>
        /// <returns></returns>
        public ButtonState GetButtonState(MOUSEBUTTON buttonEnum, MouseState mouseState)
        {
            ButtonState button = ButtonState.Released;
            switch (buttonEnum)
            {
                case MOUSEBUTTON.LEFT:
                    button = mouseState.LeftButton;
                    break;
                case MOUSEBUTTON.RIGHT:
                    button = mouseState.RightButton;
                    break;
                case MOUSEBUTTON.MIDDLE:
                    button = mouseState.MiddleButton;
                    break;
            }

            return button;
        }

        public bool IsMouseButtonDown(MOUSEBUTTON buttonEnum)
        {
            ButtonState button = GetButtonState(buttonEnum, this.mouseState);

            if (button == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public bool IsMouseButtonPressed(MOUSEBUTTON buttonEnum)
        {
            ButtonState button = GetButtonState(buttonEnum, this.mouseState);
            ButtonState oldButton = GetButtonState(buttonEnum, this.oldMouseState);

            if (button == ButtonState.Pressed &&
                oldButton == ButtonState.Released)
                return true;
            else
                return false;
        }

        // Mouse position
        public Point GetMousePosition()
        {
            return new Point(GetMouseX(), GetMouseY());
        }
        public int GetMouseX()
        {
            Camera camera = this.Game.camera;
            return (mouseState.X - ((int)camera.viewport.Width / 2)) / (int)camera.Zoom;
        }
        public int GetMouseY()
        {
            Camera camera = this.Game.camera;
            return (mouseState.Y - ((int)camera.viewport.Height / 2)) / (int)camera.Zoom;
        }

        public int GetMouseScroll()
        {
            return mouseState.ScrollWheelValue;
        }

    }
}
