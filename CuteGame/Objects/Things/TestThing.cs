using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things
{
    public class TestThing : TestThingParent
    {
        public TestThing(SpyGame game,string a, int b, int c, int caca) :base(game,caca)
        {
            Console.WriteLine("aaa");
            this.Sprite = new Sprite(this, "knight_f_idle_anim_f0");
        }
    }
}
