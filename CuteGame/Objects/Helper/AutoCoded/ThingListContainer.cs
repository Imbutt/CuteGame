//StartUsing
using CuteGame.Objects;
using CuteGame.Objects.Helper;
using CuteGame.Objects.Scenes;
using CuteGame.Objects.Things;
using CuteGame.Objects.Helper.AutoCoded;
using CuteGame.Objects.Helper.Input;
using CuteGame.Objects.Helper.Input.InputClasses;
using CuteGame.Objects.Things.Battle;
using CuteGame.Objects.Things.Battle.Characters;
using CuteGame.Objects.Things.Battle.Enemies;
using CuteGame.Objects.Things.Battle.UI;
using CuteGame.Objects.Things.Battle.UI.DiceUIFolder;
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
			 { "Sprite", typeof(Sprite) } ,
			 { "Thing", typeof(Thing) } ,
			 { "AudioManager", typeof(AudioManager) } ,
			 { "Camera", typeof(Camera) } ,
			 { "Circle", typeof(Circle) } ,
			 { "Debugger", typeof(Debugger) } ,
			 { "Drawer", typeof(Drawer) } ,
			 { "MethodsUtils", typeof(MethodsUtils) } ,
			 { "ResourceManager", typeof(ResourceManager) } ,
			 { "SpriteAnimation", typeof(SpriteAnimation) } ,
			 { "ResourceContainer", typeof(ResourceContainer) } ,
			 { "ThingListContainer", typeof(ThingListContainer) } ,
			 { "InputManager", typeof(InputManager) } ,
			 { "InputClass", typeof(InputClass) } ,
			 { "Scene", typeof(Scene) } ,
			 { "SceneBattle", typeof(SceneBattle) } ,
			 { "Block", typeof(Block) } ,
			 { "Button", typeof(Button) } ,
			 { "Slimee", typeof(Slimee) } ,
			 { "Spy", typeof(Spy) } ,
			 { "TestThing", typeof(TestThing) } ,
			 { "TestThingParent", typeof(TestThingParent) } ,
			 { "BattleCharacter", typeof(BattleCharacter) } ,
			 { "BattleCharacterTile", typeof(BattleCharacterTile) } ,
			 { "BattleDice", typeof(BattleDice) } ,
			 { "ChoseArrow", typeof(ChoseArrow) } ,
			 { "Knight", typeof(Knight) } ,
			 { "Slime", typeof(Slime) } ,
			 { "ActionUI", typeof(ActionUI) } ,
			 { "DiceUI", typeof(DiceUI) } ,
			 { "IconTile", typeof(IconTile) } ,
			 { "ActionSlot", typeof(ActionSlot) } ,
			 { "ActionTile", typeof(ActionTile) } ,
			 { "DiceSlot", typeof(DiceSlot) } ,
			 { "DiceTile", typeof(DiceTile) } ,
			 { "DiceUIComponent", typeof(DiceUIComponent) } 
        };


    }
}