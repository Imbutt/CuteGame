
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle
{
    public class BattleCharTile : Thing
    {
        public enum TYPE
        {
            ALLY,
            ENEMY,
            NEUTRAL
        }

        public TYPE Type { get; set; }
        public Vector2 Coord { get; set; }

        public BattleCharTile(SpyGame game, TYPE type, Vector2 coord) : base(game)
        {
            this.Sprite = new Sprite(this, this.Game.resourceContainer._Content._Texture._Battle.Tile_png);
            this.Type = type;
            this.Coord = coord;
        }

        public override void Update()
        {

            base.Update();
        }


        public override void Draw()
        {


            this.Game.drawer.DrawStringDebug(this.Position.X + " " + this.Position.Y);

            base.Draw();
            this.DrawPosition();
        }
    }
}
