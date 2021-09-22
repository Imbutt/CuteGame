//StartUsing
using CuteGame.Objects.Things;
using CuteGame.Objects.Things.Battle;
using CuteGame.Objects.Things.Battle.Characters;
using CuteGame.Objects.Things.Battle.Enemies;
using CuteGame.Objects.Things.Battle.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper.AutoCoded
{
    public class ThingListContainer
    {
        public SpyGame Game { get; private set; }

        // Auto generated dictionary, do not touch
        public Dictionary<string, Type> ThingsDict { get; private set; } = new Dictionary<string, Type>()
        {
            //StartDict
			 { "Block", typeof(Block) } ,
			 { "Spy", typeof(Spy) } ,
			 { "BattleCharacter", typeof(BattleCharacter) } ,
			 { "ChoseArrow", typeof(ChoseArrow) } ,
			 { "Knight", typeof(Knight) } ,
			 { "Slime", typeof(Slime) } ,
			 { "ActionUI", typeof(ActionUI) } ,
			 { "IconTile", typeof(IconTile) } 
        };


    }
}