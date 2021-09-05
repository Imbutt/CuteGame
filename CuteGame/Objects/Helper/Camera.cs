using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuteGame.Objects.Helper
{
    public class Camera
    {
        public SpyGame Game { get; private set; }

        private Matrix transform;
        public Matrix Transfrom
        {
            get { return transform; }
        }

        public Viewport viewport;
        private float zoom = 1;
        private float rotation = 0;

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        private Vector2 oldPosition = new Vector2(0, 0);

        public float X
        {
            get { return Position.X; }
            set { Position = new Vector2(value,Position.Y); }
        }

        public float Y
        {
            get { return Position.Y; }
            set { Position = new Vector2(Position.X,value); }
        }

        public float Zoom
        {
            get { return zoom; }
            set 
            {
                zoom = value;
                if (zoom < 0.1f)
                    zoom = 0.1f;
            }
        }

        public float Rotation 
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update()
        {
            oldPosition = Position;

            transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));

        }
    }
}
