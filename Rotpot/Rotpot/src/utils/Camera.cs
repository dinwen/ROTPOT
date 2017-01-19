﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan.utils
{
    public class Camera
    {
        private readonly Viewport _viewport;

        private bool shake = false;
        private int shakeTime;
        private int shakeAmount;
        private float shakeCooldown = 10;

        private static Random random = new Random();

        public Camera(Viewport viewport)
        {
            _viewport = viewport;

            Rotation = 0;
            Zoom = 1;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }

        public void Update()
        {
            if(shake)
            {
                if(--shakeCooldown <= 0)
                {
                    shakeCooldown = 2;
                    Position = new Vector2(random.Next(shakeAmount * 2) - shakeAmount, random.Next(shakeAmount * 2) - shakeAmount);
                }
                if(--shakeTime <= 0)
                {
                    shake = false;
                    shakeTime = 0;
                    Position = new Vector2(0, 0);
                }
            }
        }

        public void Shake(int time, int amount)
        {
            shake = true;
            shakeTime += time;
            shakeAmount = amount;
        }

        public Matrix ViewMatrix
        {
            get
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
}
