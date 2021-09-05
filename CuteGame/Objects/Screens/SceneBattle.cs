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

        int allyXPos = -100;
        int enemyXPos = 100;

        int characterYStart = 30;
        int characterYOffset = 15;

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

            // Setup arrow (who the player is controlling right now)
            selectArrow = new ChoseArrow(this.Game);
            this.Game.CreateInstance(selectArrow, new Vector2(0, 0));
            targetArrow = new ChoseArrow(this.Game);
            this.Game.CreateInstance(targetArrow, new Vector2(0, 0));

            // Create allies and enemies
            for (int i = 0; i < listAllies.Count; i++)
            {
                this.Game.CreateInstance(listAllies[i],
                    new Vector2(allyXPos, characterYStart +
                    (characterYOffset + listAllies[i].Sprite.Texture.Height) * i));
            }

            for (int i = 0; i < listEnemies.Count; i++)
            {
                listEnemies[i].Rotation = 180;
                this.Game.CreateInstance(listEnemies[i],
                    new Vector2(enemyXPos, characterYStart + 
                    (characterYOffset + listEnemies[i].Sprite.Texture.Height) * i));
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
            this.Game.soundManager.PlaySoundName("Audio/select");
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
