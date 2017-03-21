using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class Camera
    {
        private readonly Viewport _viewport;
        private float width, height;

        public Camera(Viewport viewport)
        {
            _viewport = viewport;

            Rotation = 0;
            Zoom = 2;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public Vector2 Position;
        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }

        public void SetLevelSize(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public void Update()
        {
            if (Position.X < 0) Position.X = 0;
            if (Position.Y < 0) Position.Y = 0;
            if (Position.X > width - 1920) Position.X = width - 1920;
            if (Position.Y > height - 1080) Position.Y = height - 1080;
        }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }
    }
}
