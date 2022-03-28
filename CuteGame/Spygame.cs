using CuteGame.Objects;
using CuteGame.Objects.Helper;
using CuteGame.Objects.Helper.Input.InputClasses;
using CuteGame.Objects.Scenes;
using CuteGame.Objects.Things;
using CuteGame.Objects.Things.Battle.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CuteGame.Objects.Things.Battle;
using CuteGame.Objects.Things.Battle.Enemies;
using MonoGame_LDtk_Importer;
using System.Linq;
using CuteGame.Objects.Helper.AutoCoded;

namespace CuteGame
{
    public class SpyGame : Game
    {
        public string MainPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + @"\SpyGame";

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        // static class to here
        public GameWindow gamewindow;
        // Managers
        public ResourceManager resourceManager;
        public AudioManager audioManager;
        public InputManager inputManager;

        public Drawer drawer;

        

        private bool isFirstUpdate = true;

        public float globalScale = 1;

        public Camera camera;
        public Scene gameScene;
        
        // Autocoded class containers
        public ThingListContainer thingListContainer;
        public ResourceContainer resourceContainer;
        public Random _random = new Random();
        

        public LDtkProject ldtkProject;

        public SpriteBatch SpriteBatch
        {
            get => _spriteBatch;
            protected set
            {
                _spriteBatch = value;
            }
        }

        public List<Thing> listInstances = new List<Thing>();


        public SpyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize managers
            inputManager = new InputManager(this);
            resourceManager = new ResourceManager(this);
            audioManager = new AudioManager(this);

            // Create autocoded class containers
            thingListContainer = new ThingListContainer();
            resourceContainer = new ResourceContainer();

            gamewindow = Window;

            drawer = new Drawer(this);

            // Check folder and files
            if (!Directory.Exists(MainPath))
                Directory.CreateDirectory(MainPath);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // WARN! Dirty hack to load the ltdk project (will be fixed with the updated github?)
            // Using STATIC path for debuggin purposes, should make something beter for release
            // https://github.com/chamalowmoelleux/MonoGame-LDtk-Importer
            string path = @"C:\Users\Utente\AppData\Local\Programs\ldtk\project\CuteGame.json";
            ldtkProject = new LDtkProject(path);

            // Resolution and fullscreen
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            //_graphics.ToggleFullScreen();

            // camera?
            camera = new Camera(GraphicsDevice.Viewport);
            this.camera.Position = new Vector2(0, 0);


            // Create sample player

            
            SceneBattle sceneBattle = new SceneBattle(this);
            sceneBattle.listEnemies = new List<BattleCharacter>()
            {
                new Slime(this,sceneBattle),
                new Slime(this,sceneBattle)
            };

            sceneBattle.listAllies = new List<BattleCharacter>()
            {
                new Knight(this,sceneBattle),
                new Knight(this,sceneBattle)
            };
            ChangeScene(sceneBattle);
           

            Scene scene = new Scene(this, "TestLevel");
            ChangeScene(scene);





            // Test scene

            //Scene superNice = new Scene(this,"Test");
            //this.ChangeScene(superNice);
        }

        protected override void Update(GameTime gameTime)
        {
            if(isFirstUpdate)
            {
                //this.camera.Position = new Vector2(20,20);
                isFirstUpdate = false;


            }

            inputManager.UpdateInputStates();

            // Pre Update
            if (this.gameScene != null)
            {
                //gameScene.PreUpdate();
            }
            foreach (Thing instance in listInstances)
            {
                instance.PreUpdate();
            }

            //Update
            this.camera.Update();

            // Update event of every instance
            foreach (Thing instance in listInstances)
            {
                instance.Update();
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                SamplerState.PointClamp, null, null,null, camera.Transfrom);

            if (this.gameScene != null)
                gameScene.Draw();

            foreach (Thing instance in listInstances)
            {
                instance.Draw();
            }


            // Post
            foreach (Thing instance in listInstances)
            {
                instance.PostDraw();
            }

            if (this.gameScene != null)
                gameScene.PostDraw();


            for (int i = 0; i < drawer.DebugStrings.Count; i++)
            {
                drawer.DrawStringHud(drawer.DebugStrings[i], new Vector2(10, 15 * i));
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // Methods
        protected void CreateInstance(Thing thing)
        {
            CreateInstance(thing, new Vector2(0, 0));
        }

        public Thing CreateInstance(Thing thing, Vector2 pos)
        {
            thing.Position = pos;

            listInstances.Add(thing);   // Add to list of instances

            thing.Create(); // Create event of the instance

            return thing;
        }



        // Change currentScene to another scene
        public void ChangeScene(Scene scene)
        {
            // Unload current scene
            foreach(Thing thing in listInstances)
            {
                if (thing.Persistent != true)
                    listInstances.Remove(thing);
            }

            // Unload resouces
            this.resourceManager.UnloadResources();

            // Load new scene
            this.gameScene = scene;
            listInstances.AddRange(gameScene.listInstances);

            // Scene method
            this.gameScene.OnCreate();
        }


    }
}
