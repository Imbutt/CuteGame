using CuteGame.Objects.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI
{
    public class ActionUI : Thing
    {
        public SceneBattle ParentSceneBattle { get; set; }

        // Tiles variables
        private List<IconTile> listIconTiles;
        private int offsetX = 10;

        private enum STATE
        {
            SELECTING,
            TARGETING
        }
        private STATE currentState = STATE.SELECTING;

        // Selecting variables
        private int chosenN = 0;
        private IconTile chosenTile;

        // Targeting variables
        private int targetN = 0;
        private BattleCharacter targetChar;

        public ActionUI(SpyGame game, SceneBattle scenebattle) : base(game)
        {
            this.ParentSceneBattle = scenebattle;
        }

        public override void Update()
        {
            // Update the position of all icontiles to the actionUI
            for (int i = 0; i < listIconTiles.Count; i++)
            {
                // WARN: possible out of bounds
                listIconTiles[i].Position = 
                    new Vector2(this.PosX + (listIconTiles[0].Sprite.Texture.Width + offsetX ) * i, 
                    this.PosY);
            }

           
            

            base.Update();
        }

        public override void Draw()
        {
            this.Game.drawer.DrawStringHud(this.targetN.ToString(), new Vector2(20, 20));
            base.Draw();
        }

        public override void Create()
        {
            // Create all iconTiles
            listIconTiles = new List<IconTile>()
            {
                new IconTile(Game,this,IconTile.TYPE.ATTACK),
                new IconTile(Game,this,IconTile.TYPE.BLOCK),
                new IconTile(Game,this,IconTile.TYPE.HEAL),
                new IconTile(Game,this,IconTile.TYPE.EXIT)
            };

            for (int i = 0; i < listIconTiles.Count; i++)
            {
                this.Game.CreateInstance(listIconTiles[i], new Vector2(0, 0));
            }

            chosenTile = listIconTiles[0];  // First chosen icontile
            chosenTile.Sprite.Color = Color.Red;

            base.Create();
        }
    }
}
