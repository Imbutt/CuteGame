using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper.AutoCoded
{
	public class EnumListContainer
	{
		public CuteGame _CuteGame { get; private set; } = new CuteGame();
		public class CuteGame
		{
			//Files(CuteGame)


			//Subdirs(CuteGame)
			public Properties _Properties { get; private set; } = new Properties();
			public class Properties
			{
				//Files(CuteGame:Properties)
				public Files _Files { get; private set; } = new Files();
				public enum Files
				{
					//Enum(CuteGame:Properties)
					launchSettings_json
				}
				
				//Subdirs(CuteGame:Properties)
			}
			public Objects _Objects { get; private set; } = new Objects();
			public class Objects
			{
				//Sprite_cs,
				//Thing_cs

				//Files(CuteGame:Objects)
				public Files _Files { get; set; } = new Files();
                public class Files
                {
					// FileClass(CuteGame:Objects)
					public Sprite _Sprite { get; set; } = new Sprite();
                    public class Sprite
                    {
                        public string Name { get; set; }
                        public string Path { get; set; }
                        public string AbsolutePath { get; set; }
                    }
                }
				
				//Subdirs(CuteGame:Objects)
				public Things _Things { get; private set; } = new Things();
				public class Things
				{
					//Files(CuteGame:Objects:Things)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Objects:Things)
						Block_cs,
						Spy_cs
					}
					
					//Subdirs(CuteGame:Objects:Things)
					public Battle _Battle { get; private set; } = new Battle();
					public class Battle
					{
						//Files(CuteGame:Objects:Things:Battle)
						public Files _Files { get; private set; } = new Files();
						public enum Files
						{
							//Enum(CuteGame:Objects:Things:Battle)
							BattleCharacter_cs,
							ChoseArrow_cs
						}
						
						//Subdirs(CuteGame:Objects:Things:Battle)
						public UI _UI { get; private set; } = new UI();
						public class UI
						{
							//Files(CuteGame:Objects:Things:Battle:UI)
							public Files _Files { get; private set; } = new Files();
							public enum Files
							{
								//Enum(CuteGame:Objects:Things:Battle:UI)
								ActionUI_cs,
								IconTile_cs
							}
							
							//Subdirs(CuteGame:Objects:Things:Battle:UI)
						}
						public Enemies _Enemies { get; private set; } = new Enemies();
						public class Enemies
						{
							//Files(CuteGame:Objects:Things:Battle:Enemies)
							public Files _Files { get; private set; } = new Files();
							public enum Files
							{
								//Enum(CuteGame:Objects:Things:Battle:Enemies)
								Slime_cs
							}
							
							//Subdirs(CuteGame:Objects:Things:Battle:Enemies)
						}
						public Characters _Characters { get; private set; } = new Characters();
						public class Characters
						{
							//Files(CuteGame:Objects:Things:Battle:Characters)
							public Files _Files { get; private set; } = new Files();
							public enum Files
							{
								//Enum(CuteGame:Objects:Things:Battle:Characters)
								Knight_cs
							}
							
							//Subdirs(CuteGame:Objects:Things:Battle:Characters)
						}
					}
				}
				public Sprites _Sprites { get; private set; } = new Sprites();
				public class Sprites
				{
					//Files(CuteGame:Objects:Sprites)
					
					//Subdirs(CuteGame:Objects:Sprites)
				}
				public Screens _Screens { get; private set; } = new Screens();
				public class Screens
				{
					//Files(CuteGame:Objects:Screens)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Objects:Screens)
						Scene_cs,
						SceneBattle_cs
					}
					
					//Subdirs(CuteGame:Objects:Screens)
				}
				public Helper _Helper { get; private set; } = new Helper();
				public class Helper
				{
					//Files(CuteGame:Objects:Helper)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Objects:Helper)
						Camera_cs,
						CollisionClass_cs,
						Debugger_cs,
						Drawer_cs,
						MethodsUtils_cs,
						SoundManager_cs,
						SpriteManager_cs
					}
					
					//Subdirs(CuteGame:Objects:Helper)
					public Input _Input { get; private set; } = new Input();
					public class Input
					{
						//Files(CuteGame:Objects:Helper:Input)
						public Files _Files { get; private set; } = new Files();
						public enum Files
						{
							//Enum(CuteGame:Objects:Helper:Input)
							InputManager_cs
						}
						
						//Subdirs(CuteGame:Objects:Helper:Input)
						public InputClasses _InputClasses { get; private set; } = new InputClasses();
						public class InputClasses
						{
							//Files(CuteGame:Objects:Helper:Input:InputClasses)
							public Files _Files { get; private set; } = new Files();
							public enum Files
							{
								//Enum(CuteGame:Objects:Helper:Input:InputClasses)
								InputClass_cs
							}
							
							//Subdirs(CuteGame:Objects:Helper:Input:InputClasses)
						}
					}
					public AutoCoded _AutoCoded { get; private set; } = new AutoCoded();
					public class AutoCoded
					{
						//Files(CuteGame:Objects:Helper:AutoCoded)
						public Files _Files { get; private set; } = new Files();
						public enum Files
						{
							//Enum(CuteGame:Objects:Helper:AutoCoded)
							EnumListContainer_cs,
							ThingListContainer_cs
						}
						
						//Subdirs(CuteGame:Objects:Helper:AutoCoded)
					}
				}
			}
			public Content _Content { get; private set; } = new Content();
			public class Content
			{
				//Files(CuteGame:Content)
				public Files _Files { get; private set; } = new Files();
				public enum Files
				{
					//Enum(CuteGame:Content)
					Content_mgcb,
					CuteGame_json,
					DinoSprites_doux_gif,
					floor_1_png,
					knight_f_idle_anim_f0_png,
					point_png
				}
				
				//Subdirs(CuteGame:Content)
				public Texture _Texture { get; private set; } = new Texture();
				public class Texture
				{
					//Files(CuteGame:Content:Texture)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Content:Texture)
						block_png
					}
					
					//Subdirs(CuteGame:Content:Texture)
					public Slime _Slime { get; private set; } = new Slime();
					public class Slime
					{
						//Files(CuteGame:Content:Texture:Slime)
						
						//Subdirs(CuteGame:Content:Texture:Slime)
					}
					public Player _Player { get; private set; } = new Player();
					public class Player
					{
						//Files(CuteGame:Content:Texture:Player)
						
						//Subdirs(CuteGame:Content:Texture:Player)
					}
					public BigDemon _BigDemon { get; private set; } = new BigDemon();
					public class BigDemon
					{
						//Files(CuteGame:Content:Texture:BigDemon)
						public Files _Files { get; private set; } = new Files();
						public enum Files
						{
							//Enum(CuteGame:Content:Texture:BigDemon)
							big_demon_idle_anim_f0_png,
							big_demon_idle_anim_f1_png,
							big_demon_idle_anim_f2_png,
							big_demon_idle_anim_f3_png,
							big_demon_run_anim_f0_png,
							big_demon_run_anim_f1_png,
							big_demon_run_anim_f2_png,
							big_demon_run_anim_f3_png
						}
						
						//Subdirs(CuteGame:Content:Texture:BigDemon)
					}
					public Battle _Battle { get; private set; } = new Battle();
					public class Battle
					{
						//Files(CuteGame:Content:Texture:Battle)
						public Files _Files { get; private set; } = new Files();
						public enum Files
						{
							//Enum(CuteGame:Content:Texture:Battle)
							iconAttack_png,
							iconBlock_png,
							iconExit_png,
							iconHeal_png,
							iconTile_png
						}
						
						//Subdirs(CuteGame:Content:Texture:Battle)
					}
				}
				public Font _Font { get; private set; } = new Font();
				public class Font
				{
					//Files(CuteGame:Content:Font)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Content:Font)
						Default_spritefont,
						File_spritefont
					}
					
					//Subdirs(CuteGame:Content:Font)
				}
				public Audio _Audio { get; private set; } = new Audio();
				public class Audio
				{
					//Files(CuteGame:Content:Audio)
					public Files _Files { get; private set; } = new Files();
					public enum Files
					{
						//Enum(CuteGame:Content:Audio)
						hit_wav,
						jump_wav,
						select_wav
					}
					
					//Subdirs(CuteGame:Content:Audio)
				}
			}
		}
		
	}

}