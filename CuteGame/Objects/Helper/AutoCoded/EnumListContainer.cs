using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace CuteGame.Objects.Helper.AutoCoded
{
	public class EnumListContainer
	{
		public Content _Content { get; private set; } = new Content();
		public class Content
		{
			//Files(Content)
				public AutoCodedFile point_png { get; private set; } = new AutoCodedFile("point.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\point.png",@"point",@".png");
				public AutoCodedFile knight_f_idle_anim_f0_png { get; private set; } = new AutoCodedFile("knight_f_idle_anim_f0.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\knight_f_idle_anim_f0.png",@"knight_f_idle_anim_f0",@".png");
				public AutoCodedFile floor_1_png { get; private set; } = new AutoCodedFile("floor_1.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\floor_1.png",@"floor_1",@".png");
				public AutoCodedFile DinoSprites_doux_gif { get; private set; } = new AutoCodedFile("DinoSprites_doux.gif",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\DinoSprites_doux.gif",@"DinoSprites_doux",@".gif");
				public AutoCodedFile CuteGame_json { get; private set; } = new AutoCodedFile("CuteGame.json",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\CuteGame.json",@"CuteGame",@".json");
				public AutoCodedFile Content_mgcb { get; private set; } = new AutoCodedFile("Content.mgcb",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Content.mgcb",@"Content",@".mgcb");
			
			//Subdirs(Content)
			public Texture _Texture { get; private set; } = new Texture();
			public class Texture
			{
				//Files(Content:Texture)
					public AutoCodedFile block_png { get; private set; } = new AutoCodedFile("block.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\block.png",@"Texture\block",@".png");
				
				//Subdirs(Content:Texture)
				public Slime _Slime { get; private set; } = new Slime();
				public class Slime
				{
					//Files(Content:Texture:Slime)
					
					//Subdirs(Content:Texture:Slime)
				}
				public Player _Player { get; private set; } = new Player();
				public class Player
				{
					//Files(Content:Texture:Player)
					
					//Subdirs(Content:Texture:Player)
				}
				public BigDemon _BigDemon { get; private set; } = new BigDemon();
				public class BigDemon
				{
					//Files(Content:Texture:BigDemon)
						public AutoCodedFile big_demon_run_anim_f3_png { get; private set; } = new AutoCodedFile("big_demon_run_anim_f3.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_run_anim_f3.png",@"Texture\BigDemon\big_demon_run_anim_f3",@".png");
						public AutoCodedFile big_demon_run_anim_f2_png { get; private set; } = new AutoCodedFile("big_demon_run_anim_f2.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_run_anim_f2.png",@"Texture\BigDemon\big_demon_run_anim_f2",@".png");
						public AutoCodedFile big_demon_run_anim_f1_png { get; private set; } = new AutoCodedFile("big_demon_run_anim_f1.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_run_anim_f1.png",@"Texture\BigDemon\big_demon_run_anim_f1",@".png");
						public AutoCodedFile big_demon_run_anim_f0_png { get; private set; } = new AutoCodedFile("big_demon_run_anim_f0.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_run_anim_f0.png",@"Texture\BigDemon\big_demon_run_anim_f0",@".png");
						public AutoCodedFile big_demon_idle_anim_f3_png { get; private set; } = new AutoCodedFile("big_demon_idle_anim_f3.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_idle_anim_f3.png",@"Texture\BigDemon\big_demon_idle_anim_f3",@".png");
						public AutoCodedFile big_demon_idle_anim_f2_png { get; private set; } = new AutoCodedFile("big_demon_idle_anim_f2.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_idle_anim_f2.png",@"Texture\BigDemon\big_demon_idle_anim_f2",@".png");
						public AutoCodedFile big_demon_idle_anim_f1_png { get; private set; } = new AutoCodedFile("big_demon_idle_anim_f1.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_idle_anim_f1.png",@"Texture\BigDemon\big_demon_idle_anim_f1",@".png");
						public AutoCodedFile big_demon_idle_anim_f0_png { get; private set; } = new AutoCodedFile("big_demon_idle_anim_f0.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\BigDemon\big_demon_idle_anim_f0.png",@"Texture\BigDemon\big_demon_idle_anim_f0",@".png");
					
					//Subdirs(Content:Texture:BigDemon)
				}
				public Battle _Battle { get; private set; } = new Battle();
				public class Battle
				{
					//Files(Content:Texture:Battle)
						public AutoCodedFile iconTile_png { get; private set; } = new AutoCodedFile("iconTile.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\Battle\iconTile.png",@"Texture\Battle\iconTile",@".png");
						public AutoCodedFile iconHeal_png { get; private set; } = new AutoCodedFile("iconHeal.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\Battle\iconHeal.png",@"Texture\Battle\iconHeal",@".png");
						public AutoCodedFile iconExit_png { get; private set; } = new AutoCodedFile("iconExit.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\Battle\iconExit.png",@"Texture\Battle\iconExit",@".png");
						public AutoCodedFile iconBlock_png { get; private set; } = new AutoCodedFile("iconBlock.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\Battle\iconBlock.png",@"Texture\Battle\iconBlock",@".png");
						public AutoCodedFile iconAttack_png { get; private set; } = new AutoCodedFile("iconAttack.png",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Texture\Battle\iconAttack.png",@"Texture\Battle\iconAttack",@".png");
					
					//Subdirs(Content:Texture:Battle)
				}
			}
			public Font _Font { get; private set; } = new Font();
			public class Font
			{
				//Files(Content:Font)
					public AutoCodedFile File_spritefont { get; private set; } = new AutoCodedFile("File.spritefont",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Font\File.spritefont",@"Font\File",@".spritefont");
					public AutoCodedFile Default_spritefont { get; private set; } = new AutoCodedFile("Default.spritefont",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Font\Default.spritefont",@"Font\Default",@".spritefont");
				
				//Subdirs(Content:Font)
			}
			public Audio _Audio { get; private set; } = new Audio();
			public class Audio
			{
				//Files(Content:Audio)
					public AutoCodedFile select_wav { get; private set; } = new AutoCodedFile("select.wav",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Audio\select.wav",@"Audio\select",@".wav");
					public AutoCodedFile jump_wav { get; private set; } = new AutoCodedFile("jump.wav",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Audio\jump.wav",@"Audio\jump",@".wav");
					public AutoCodedFile hit_wav { get; private set; } = new AutoCodedFile("hit.wav",@"D:\Users\Andrea\Desktop\progamazore\repos\REPOS 2\CuteGame\CuteGame/Content\Audio\hit.wav",@"Audio\hit",@".wav");
				
				//Subdirs(Content:Audio)
			}
		}
		
	}

}