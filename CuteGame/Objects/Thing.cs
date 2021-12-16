using CuteGame.Objects.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using static CuteGame.Objects.Helper.InputManager;

namespace CuteGame.Objects
{
    public abstract class Thing
    {
        public SpyGame Game { get; private set; }   // Used to reference the game methods and parameters
        public bool Persistent { get; set; } // The instance doesn't get deleted when changing scene
        public float Scale { get; set; } = 1;
        public float Rotation { get; set; } = 0;
        // Used to move the instance while applying collisions if called
        public Vector2 Velocity { get; set; } = Vector2.Zero;
        public float VelX
        {
            get { return this.Velocity.X; }
            set { this.Velocity = new Vector2(value, this.Velocity.Y); }
        }
        public float VelY
        {
            get { return this.Velocity.Y; }
            set { this.Velocity = new Vector2(this.Velocity.X, value); }
        }
        // Position of the sprite to draw and of the collisionbox
        public Vector2 Position { get; set; }
        public float PosX
        {
            get { return this.Position.X; }
            set { this.Position = new Vector2(value, this.Position.Y); } 
        }
        public float PosY
        {
            get { return this.Position.Y; }
            set { this.Position = new Vector2(this.Position.X, value); }
        }

        public Sprite Sprite { get; set; }

        // Collision
        public Rectangle CollisionBox { get; set; }

        public Rectangle AbsoluteCollisionBox
        {
            get
            {
                return new Rectangle(new Point((int)this.PosX - this.CollisionBox.Width / 2,
              (int)this.PosY - this.CollisionBox.Height / 2), this.CollisionBox.Size);
            }
            private set { }
        }


        /*
                 private string _spriteResource;
        public string SpriteResource
        {
            get => _spriteResource;
            set
            {
                Sprite = Game.GetSprite(value);
                _spriteResource = value;
            }
        }

        private Texture2D _sprite = null;
        public Color SpriteColor { get; set; } = Color.White;
        public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;
        public Vector2 SpriteOrigin { get; set; }
        public float SpriteDepth { get; set; } = 0;
        public Texture2D Texture
        {
            get => _sprite;

            set
            {
                _sprite = value;
                this.SpriteOrigin = new Vector2(this.Sprite.Width / 2, this.Sprite.Height / 2);
            }
        }
         * */

        // When moving the instance using the velocity, it collides and won't overlap with
        // these type of instances
        public List<Type> CollidesWithTypes = new List<Type>();
        

        // Methods
        public Thing(SpyGame game)
        {
            Game = game;
            // Default values
            this.CollisionBox = this.GetDefaultCollisionBox();
        }

        public virtual void Create() { }
        public virtual void PreUpdate() { }
        public virtual void Update() 
        {
        }

        public virtual void PostUpdate() { }

        public virtual void PreDraw() { }

        public virtual void Draw() 
        {
            if(this.Sprite != null)
            {
                if (this.Sprite.Anim != null)
                    this.Sprite.UpdateAnimation();
                this.DrawCollisionBox();
                this.DrawSprite();
            }
        }

        public virtual void PostDraw() { }

        /// <summary>
        /// Moves the instance to its velocity
        /// </summary>
        /// <param name="resetVelocity"> Reset the instance velocity to 0</param>
        public void ApplyVelocity(bool resetVelocity)
        {
            this.Position = new Vector2(this.Position.X + this.Velocity.X,
                this.Position.Y + this.Velocity.Y);

            if (resetVelocity)
                this.Velocity = new Vector2(0, 0);
        }

        /// <summary>
        /// Draws the sprite of the instance to the screen using its special effects
        /// </summary>
        public void DrawSprite()
        {
            if (this.Sprite != null && this.Sprite.Visible)
            {
                Game._spriteBatch.Draw(this.Sprite.Texture, this.Position, null, this.Sprite.Color,
                    this.Sprite.Rotation, this.Sprite.Origin, this.Scale * Game.globalScale,
                    this.Sprite.Effect, this.Sprite.Depth);
            }
        }

        /// <summary>
        /// Draws the instance collision box
        /// </summary>
        public void DrawCollisionBox()
        {
            // Draw collision box
            var sprite = Game.resourceManager.GetTexture("point");
            Game._spriteBatch.Draw(sprite, AbsoluteCollisionBox, new Color(255, 0, 255, 100));
        }

        /// <summary>
        /// Applies the collisions, which means if the instance is about to collide with
        /// one of the types listed in the CollidesWithTypes list it will stop
        /// </summary>
        public void ApplyCollisionsVelocity()
        {
            foreach (Type type in CollidesWithTypes)
            {
                if (IsCollidingType(type, this.VelX, 0).Count > 0)
                    this.VelX = 0;
                if (IsCollidingType(type, 0, this.VelY).Count > 0)
                    this.VelY = 0;
            }
        }
        public Rectangle GetDefaultCollisionBox()
        {
            if (this.Sprite != null && this.Sprite.Texture != null)
            {
                return new Rectangle(
                    (int)this.Position.X - this.Sprite.Texture.Width / 2,
                    (int)this.Position.Y - this.Sprite.Texture.Height / 2,
                    this.Sprite.Texture.Width, this.Sprite.Texture.Height);
            }
            else
                return new Rectangle(0, 0, 0, 0);
        }

        /// <summary>
        /// Returns the list of the instances the caller is colliding with.
        /// Uses the velocity offset of the caller.
        /// </summary>
        /// <param name="thingType"></param>
        /// <returns></returns>
        public List<Thing> IsCollidingType(Type thingType)
        {
            return IsCollidingType(thingType,this.VelX,this.VelY);
        }

        public bool IsCollidingThing(Thing thing, float plusX, float plusY)
        {
            // Create a rectangle based on the collisionbox of the caller and add its velocity
            Rectangle RectangleVelocity = new Rectangle(new Point(this.AbsoluteCollisionBox.X + (int)plusX,
                this.AbsoluteCollisionBox.Y + (int)plusY), AbsoluteCollisionBox.Size);
            // Create a rectangle out of the caller and the thing being checked overlap
            Rectangle intersect = Rectangle.Intersect(RectangleVelocity, thing.AbsoluteCollisionBox);

            // If there's an existing overlapping rectangle add it to the list
            if (intersect.Width > 0 || intersect.Height > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns the list of the instances the caller is colliding with.
        /// Can add an offset to the colliding box
        /// </summary>
        /// <param name="thingType">  </param>
        /// <param name="plusX"></param>
        /// <param name="plusY"></param>
        /// <returns></returns>
        public List<Thing> IsCollidingType(Type thingType, float plusX, float plusY)
        {
            // Filter only the things of the specific type parameter
            List<Thing> thingList = (from _thing in this.Game.listInstances
                    where _thing.GetType() == thingType
                    select _thing).ToList();


            List<Thing> thingCollidedList = new List<Thing>();
            foreach(Thing thing in thingList)
            {
                if(IsCollidingThing(thing,plusX,plusY))
                    thingCollidedList.Add(thing);
            }

            return thingCollidedList;
        }

        public bool IsClickedDown(MOUSEBUTTON buttonEnum)
        {
            if (this.Game.inputManager.IsMouseButtonDown(buttonEnum) &&
                this.AbsoluteCollisionBox.Contains(this.Game.inputManager.GetMousePosition()))
                return true;
            else
                return false;
        }


        public bool IsClickedPressed(MOUSEBUTTON buttonEnum)
        {
            /*
            if (this.Game.inputManager.IsMouseButtonPressed(buttonEnum) &&
                this.CollisionBox.Contains(this.Game.inputManager.GetMousePosition()))
                return true;
            else
                return false;
            */

            if (this.Game.inputManager.IsMouseButtonPressed(buttonEnum))
                if(this.AbsoluteCollisionBox.Contains(this.Game.inputManager.GetMousePosition()))
                return true;

            return false;
        }

        public void DrawPosition()
        {
            this.Game.drawer.DrawString("Font/Default", $"{this.PosX} {this.PosY}",
new Vector2(this.PosX, this.PosY + 20), Color.White);
        }

    }
}
