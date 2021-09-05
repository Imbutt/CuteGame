using Newtonsoft.Json;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper.Input.InputClasses
{
    public class InputClass 
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        private Type type;

        public InputClass()
        {
        }
    }

    public class InputPlayer : InputClass
    {
        public InputPlayer()
        {
        }

        public Keys Right { get; set; } = Keys.D;
        public Keys Left { get; set; } = Keys.A;
        public Keys Up { get; set; } = Keys.W;
        public Keys Down { get; set; } = Keys.S;

        public Keys Special { get; set; } = Keys.E;
        public Keys Jump { get; set; } = Keys.Space;
    }


    public class InputGame : InputClass
    {
        public InputGame()
        {
        }

        public Keys Menu { get; set; }
    }
}
