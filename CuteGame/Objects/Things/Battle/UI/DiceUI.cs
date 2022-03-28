using CuteGame.Objects.Scenes;
using CuteGame.Objects.Things.Battle.UI.DiceUIFolder;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI
{
    public class DiceUI
    {
        // All components of the DiceUI
        public Dictionary<Point, DiceSlot> DiceSlotDictionary { get; private set; } = new Dictionary<Point, DiceSlot>();
        public Dictionary<int, ActionTile> ActionTileDictionary { get; private set; } = new Dictionary<int, ActionTile>();
        public Dictionary<int, DiceTile> DiceTileDictionary { get; set; } = new Dictionary<int, DiceTile>();
        public ActionSlot ActionSlot { get; private set; }

        public DiceUI(Scene diceUIScene)
        {
            // Assign all objects of the scene to the corrispondent component list or variable
            foreach(Thing obj in diceUIScene.listInstances)
            {
                if (obj is DiceSlot)
                    DiceSlotDictionary.Add(((DiceSlot)obj).SlotPosition, (DiceSlot)obj);
                else if (obj is ActionTile)
                    ActionTileDictionary.Add(((ActionTile)obj).TileNum, (ActionTile)obj);
                else if (obj is DiceTile)
                    DiceTileDictionary.Add(((DiceTile)obj).TileNum, (DiceTile)obj);
                else if (obj is ActionSlot)
                    ActionSlot = (ActionSlot)obj;
                else
                    throw new Exception("Non DiceUIComponent found in the DiceUIScene");   // If any weird unintended item is inside the diceUIScene
            }
        }


    }
}
