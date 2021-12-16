using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Things.Battle.UI
{
    // UNUSED
    public class IconTile : Thing
    {
        public enum TYPE
        {
            ATTACK,
            BLOCK,
            HEAL,
            EXIT
        }

        // Texture of the icon on top of the tile
        Dictionary<TYPE, string> tileSpriteDict = new Dictionary<TYPE, string>()
        {
            { TYPE.ATTACK,"Texture/Battle/iconAttack" },
            { TYPE.BLOCK, "Texture/Battle/iconBlock" },
            { TYPE.HEAL, "Texture/Battle/iconHeal" },
            { TYPE.EXIT, "Texture/Battle/iconExit" }
        };


        string textureResource;
        public TYPE TileType { get; set; }
        public ActionUI ParentUI { get; set; }


        public IconTile(SpyGame game,ActionUI actionUI , TYPE tileType) : base(game)
        {
            this.Sprite = new Sprite(this, "Texture/Battle/iconTile");
            this.TileType = tileType;
            this.ParentUI = actionUI;

            // Get the texture to draw on top of the tile
            tileSpriteDict.TryGetValue(this.TileType, out textureResource);

            this.CollisionBox = this.GetDefaultCollisionBox();
        }

        public override void Update()
        {
            base.Update();

            

            if(IsClickedPressed(Helper.InputManager.MOUSEBUTTON.LEFT))
            {
                this.Game.audioManager.PlaySound(this.Game.resourceContainer._Content._Audio.hit_wav);
            }
        }

        public override void PostDraw()
        {
            Game.drawer.DrawSprite(textureResource, this.Position, Color.White, 0, this.Scale, this.Sprite.Depth - 1);
            base.PostDraw();
        }
    }
}
