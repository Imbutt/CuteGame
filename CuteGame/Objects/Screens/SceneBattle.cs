using CuteGame.Objects.Screens;
using CuteGame.Objects.Things.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CuteGame.Objects.Things.Battle.UI;

namespace CuteGame.Objects.Screens
{
    public class SceneBattle : Scene
    {
        public List<BattleCharacter> listEnemies = new List<BattleCharacter>();
        public List<BattleCharacter> listAllies = new List<BattleCharacter>();

        int allyXPos;
        int enemyXPos;

        int characterYStart = 30;
        int characterYOffset = 15;
        int tileOffset = 25;

        public enum TURN
        {
            PLAYER,
            ENEMY
        }

        public TURN currentTurn = TURN.PLAYER;
        public BattleCharacter ChosenAlly { get; private set; }

        public ChoseArrow selectArrow;
        public ChoseArrow targetArrow;
        public ActionUI actionUI;

        public SceneBattle(SpyGame game) : base(game) 
        {
        }

        public override void OnCreate()
        {
            // Setup camera
            this.Game.camera.Position = new Vector2(0, 0);
            this.Game.camera.Zoom = 2;

            // TODO: AAAAAAAAAAAAAAAAA
            int width = this.Game._graphics.PreferredBackBufferWidth / 4;
            int height = this.Game._graphics.PreferredBackBufferHeight / 4;

            int tilesXPos = (int)-(width / 1.1f);
            int tilesYPos = (int)-(height / 1.5f);


            // Setup arrow (who the player is controlling right now)
            selectArrow = new ChoseArrow(this.Game);
            this.Game.CreateInstance(selectArrow, new Vector2(0, 0));
            targetArrow = new ChoseArrow(this.Game);
            this.Game.CreateInstance(targetArrow, new Vector2(0, 0));

            // Create UI
            Scene s = new Scene(this.Game);
            s.LoadLdtkScene("BattleUIScene", new Dictionary<string, object>());
            
            //this.LoadChildScene(s,new Vector2(this.Game._graphics.PreferredBackBufferWidth / 2,height),0.5f);
            this.LoadChildScene(s, new Vector2(0,0), 0.5f);



            // Create tiles of allies and enemie
            for (int u = 0; u < 2; u++)
            {
                // Change for pos and type
                BattleCharTile.TYPE type;
                int xPos;
                int yPos;
                int dir; // what direction to generate the tiles (1:from left to right, -1: from right to left)


                if (u == 0)
                {
                    type = BattleCharTile.TYPE.ALLY;
                    xPos = tilesXPos;
                    dir = 1;
                }
                else
                {
                    type = BattleCharTile.TYPE.ENEMY;
                    xPos = -tilesXPos;
                    dir = -1;
                } 

                // generate square of tiles
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        BattleCharTile tile = new BattleCharTile(this.Game, type, new Vector2(i, j));
                        this.Game.CreateInstance(tile, new Vector2(xPos + (dir * i * (tileOffset + tile.Sprite.Texture.Width))
                            , tilesYPos + (j * (tileOffset + tile.Sprite.Texture.Width))));
                    }
                }

            }


            // Create ActionUI
            actionUI = new ActionUI(this.Game,this);
            this.Game.CreateInstance(actionUI, new Vector2(0, 0));

            this.Game.camera.Position = new Vector2(0, 0);

            base.OnCreate();
        }



        public override void Update()
        {
            base.Update();

        }

        public override void Draw()
        {
            base.Draw();
            Point mousepos = this.Game.inputManager.GetMousePosition();
            this.Game.drawer.DrawStringHud($"{mousepos.X} {mousepos.Y}", new Vector2(10, 10));

            
            this.Game.drawer.DrawStringHud($"{this.Game.camera.X} {this.Game.camera.Y}  " +
                $"{this.Game.camera.viewport.Width}  {this.Game.camera.viewport.Height}   " +
                $"{this.Game.camera.Zoom}", new Vector2(10, 40));
            if (this.ChosenAlly != null)
                this.Game.drawer.DrawStringHud(ChosenAlly.ToString(), new Vector2(30, 30));
        }

        public void ChooseAlly(BattleCharacter character)
        {
            this.ChosenAlly = character;
            this.selectArrow.Position = new Vector2(this.ChosenAlly.PosX, this.ChosenAlly.PosY - 10);
            this.Game.audioManager.PlaySound("Audio/select");
        }

        public void ChooseAction()
        {
            ChosenAlly = listAllies[0];
            actionUI.Position = new Vector2(ChosenAlly.PosX, ChosenAlly.PosY - 40);
        }

        public void EndTurn()
        {
            if (currentTurn == TURN.PLAYER)
                currentTurn = TURN.ENEMY;
            else
                currentTurn = TURN.PLAYER;
        }

    }
}
