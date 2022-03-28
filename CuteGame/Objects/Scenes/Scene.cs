using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame_LDtk_Importer;
using System.Reflection;
using CuteGame.Objects.Helper;
using System.Collections;
using Microsoft.Xna.Framework;
using CuteGame.Objects.Things.Battle.UI.DiceUIFolder;

namespace CuteGame.Objects.Scenes
{
    public class Scene
    {
        public SpyGame Game { get; private set; }
        public List<Scene> ChildScenes { get; set; }
        public List<Thing> listInstances { get; set; } = new List<Thing>();
        public Level ldtkLevel;



        public Scene(SpyGame game)
        {
            Game = game;
        }

        public Scene(SpyGame game, string levelName)
        {
            Game = game;
            LoadLdtkScene(levelName, new Dictionary<string, object>());
        }

        public virtual void OnCreate()
        {

        }

        //public virtual void PreUpdate() { }
        public virtual void Update() { }
        //public virtual void PostUpdate() { }

        public virtual void PreDraw() { }
        public virtual void Draw(){ }
        public virtual void PostDraw() { }


        /// <summary>
        /// Load a scene on top of the currentScene
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="scenePos"></param>
        /// <param name="scale"></param>
        public void LoadChildScene(Scene scene, Vector2 scenePos, float scale)
        {
            int sceneW = 0, sceneH = 0;
            if (scene.ldtkLevel != null)
            {
                sceneW = scene.ldtkLevel.Width;
                sceneH = scene.ldtkLevel.Height;
            }

            // Load new scene
            foreach (Thing thing in scene.listInstances)
            {
                Vector2 pos = new Vector2((thing.PosX + scenePos.X - sceneW / 2) * scale,
                    (thing.PosY + scenePos.Y - sceneH / 2) * scale);

                thing.Scale = thing.Scale * scale;
                thing.CollisionBox = new Rectangle(new Point(thing.CollisionBox.X, thing.CollisionBox.Y),new Point(thing.CollisionBox.Width / 2, thing.CollisionBox.Height / 2));
                this.Game.CreateInstance(thing,pos);
            }
            

            // Scene method
            scene.OnCreate();
        }



        public void LoadLdtkScene(string levelName, Dictionary<string, object> objectDict)
        {
            this.ldtkLevel = this.Game.ldtkProject.GetLevelByIdentifier(levelName);
            List<Layer> entityLayerList = this.ldtkLevel.GetLayersByType(LayerType.Entities);

            Dictionary<FieldType, Tuple<Type, Type>> fieldToTypeDict = new Dictionary<FieldType, Tuple<Type, Type>>()
                    {
                        {FieldType.Int, new Tuple<Type,Type>(typeof(int),typeof(int[])) },
                        {FieldType.Float, new Tuple<Type,Type>(typeof(float),typeof(float[])) },
                        {FieldType.Bool, new Tuple<Type,Type>(typeof(bool),typeof(bool[])) },
                        {FieldType.String, new Tuple<Type,Type>(typeof(string),typeof(string[])) },
                        {FieldType.Enum, new Tuple<Type,Type>(typeof(string),typeof(string[])) },
                    };


            Dictionary<FieldType, Type> fieldSpecifyDict = new Dictionary<FieldType, Type>()
                    {
                        {FieldType.Int, typeof(IntField) },
                        {FieldType.Float, typeof(FloatField) },
                        {FieldType.Bool, typeof(BoolField) },
                        {FieldType.String, typeof(StringField) },
                        {FieldType.Enum, typeof(StringField) },
                    };


            foreach (EntitieLayer entityLayer in entityLayerList)
            {
                foreach (Entity entity in entityLayer.EntityInstances)
                {
                    // Definition of Entity to find the fields in the correct order
                    // (for some reason the fields in the entity aren't always correctly ordered)
                    var entityDef = 
                        this.Game.ldtkProject.Definitions.Entities.Find(x => x.Identifier == entity.DefUid.ToString());

                    Game.thingListContainer.ThingsDict.TryGetValue(entityDef.Identifier, out Type entityType);

                    if (entityType == null)
                        throw new Exception($"Object {entity.DefUid}:{entity.Identifier} Type not found ");


                    if (entityType == typeof(DiceSlot))
                        Console.WriteLine("xaaa");



                    ConstructorInfo[] constrArr = entityType.GetConstructors();   // Thing constructors


                    List<Field> fieldListTemp = entity.FieldInstances;  // LDTK fields
                    List<FieldDef> fieldDefList = entityDef.FieldDefList;

                    List<Field> fieldList = new List<Field>();  // LDTK fields

                    // Order Fields like FieldDefs
                    for (int i = 0; i < fieldDefList.Count; i++)
                    {
                        fieldList.Add(fieldListTemp.Find(x => x.DefUid == fieldDefList[i].DefUid));
                    }



                    Tuple<Type, Type> fieldTypeTuple = null;   // Touple of type of every parameter, (Item1: type, Item2: list<type>)

                    // Find the constructor that matches the ldtk field values
                    int validConstructor = -1;
                    if (fieldList.Count != 0)
                    {
                        for (int i = 0; i < constrArr.Length; i++)
                        {
                            ParameterInfo[] parameterInfo = constrArr[i].GetParameters();

                            if (parameterInfo.Length - 1 == fieldList.Count)
                            {
                                // If the constructor has the same number of parameters check if they correpsonds
                                // Find constructor that corresponds
                                validConstructor = i;
                                for (int j = 0; j < parameterInfo.Length - 1; j++)
                                {
                                    // Get the field types
                                    fieldToTypeDict.TryGetValue(fieldList[j].Type, out fieldTypeTuple);

                                    Type fieldType;
                                    if (!fieldList[j].IsArray)
                                        fieldType = fieldTypeTuple.Item1;
                                    else
                                        fieldType = fieldTypeTuple.Item2;

                                    // If name of parameter or type of parameter isn't equal constructor isn't valid
                                    if (parameterInfo[j + 1].Name != fieldList[j].Identifier
                                        || parameterInfo[j + 1].ParameterType != fieldType)
                                    {
                                        validConstructor = -1;
                                    }
                                }

                                // Valid constructor found, go to next step
                                if (validConstructor != -1)
                                    break;

                            }
                        }
                    }
                    else // No fields, find the constructor with just one parameter (Game parameter)
                        validConstructor = Array.FindIndex(constrArr, x => x.GetParameters().Length == 1);


                    // If finds a valid constructor
                    if (validConstructor != -1)
                    {
                        object[] inputParamsArr = new object[fieldList.Count + 1];  // Parameters to initiate Thing instance 
                        inputParamsArr[0] = this.Game;

                        if (fieldList.Count > 0)
                        {
                            for (int i = 0; i < fieldList.Count; i++)
                            {
                                // Get the field value, could be on ltdk flagged as "array", so it comes out as a list
                                // Get via reflection the first value of the subclass of Field (IntField,BoolField,StringField...)
                                // wich is always a List<T> of a specific type and cast is as a List<object>
                                /*
                                List<object> fieldValueList = ((List<object>)
                                    fieldList[i].GetType().GetProperties().First().GetValue(fieldList[i])
                                    ).Cast<object>().ToList();
                                */
                                ArrayList paramArray = null;

                                if (entityType == typeof(DiceSlot))
                                    Console.WriteLine("aa");

                                // TODO: Using this ugly else if chain right now cause nothing else works eaaaa

                                if (fieldList[i] is IntField)
                                    paramArray = new ArrayList(((IntField)fieldList[i]).Value);
                                else if (fieldList[i] is FloatField)
                                    paramArray = new ArrayList(((FloatField)fieldList[i]).Value);
                                else if (fieldList[i] is BoolField)
                                    paramArray = new ArrayList(((BoolField)fieldList[i]).Value);
                                else if (fieldList[i] is ColorField)
                                    paramArray = new ArrayList(((ColorField)fieldList[i]).Value);
                                else if (fieldList[i] is PointField)
                                    paramArray = new ArrayList(((PointField)fieldList[i]).Value);
                                else if (fieldList[i] is StringField)
                                    paramArray = new ArrayList(((StringField)fieldList[i]).Value);

                                object param = paramArray;

                                if (fieldList[i].IsArray)
                                {
                                    param = paramArray.ToArray(fieldTypeTuple.Item1);
                                }
                                else
                                    param = paramArray[0];

                                #region no clue lol
                                // fieldValies that are strings and start with "object:(object)" reference the object from the objectDict
                                // CAN'T USE THE object: AND ARRAYS BECAUSE ASS TRASH
                                if (fieldList[i].GetType() == typeof(StringField) && !fieldList[i].IsArray)
                                {
                                    // List of object gotten from the list of strings
                                        string fieldString = (string)param;

                                    if (fieldString.StartsWith("object:"))
                                    {
                                        int objectIndex = fieldString.IndexOf(':') + 1;
                                        if (fieldString.Length > objectIndex)
                                        {
                                            string objectName = fieldString.Substring(objectIndex);
                                            if (objectDict.TryGetValue(objectName, out object objectInstance))
                                            {
                                                param = objectInstance;
                                            }
                                            else
                                                throw new Exception($"Object {entity.DefUid}:{entity.Identifier} unfound object reference");
                                        }
                                    }

                                }

                                #endregion

                                inputParamsArr[i + 1] = param;


                            }

                        }

                        // Initialize and add the object to the scene's instances list
                        Thing thing = (Thing)Activator.CreateInstance(entityType, inputParamsArr);
                        thing.Position = entity.Coordinates;
                        this.listInstances.Add(thing);
                    }
                    else
                    {
                        // Can't find a constructor for the Thing instance: throw error message
                        string errorString = $"No constructor found for the thing type {constrArr.First().DeclaringType} with the fields";
                        for (int i = 0; i < fieldList.Count; i++)
                        {
                            var f = fieldList[i];
                            errorString += $"\nField({i}) Type: {f.Type.ToString()} Name:{f.Identifier}";
                        }
                        throw new Exception(errorString);
                    }



                }

            }



        }



    }
}

