using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpelProjekt.src.utils
{
    public class Animation
    {

        private Rectangle current;
        private int startX, startY;
        private int width, height, maxWidth, maxHeight;
        private int count, speed;
        private bool loop = false;
        public bool hasEnded = false;

        public Animation(int speed, int startX, int startY, int width, int height, int mWidth, int mHeight, bool loop)
        {
            this.startX = startX * width;
            this.startY = startY * height;
            this.width = width;
            this.height = height;
            this.maxWidth = mWidth;
            this.maxHeight = mHeight;
            this.speed = speed;
            this.loop = loop;
            this.current = new Rectangle(this.startX, this.startY, width, height);
        }

        public void Update()
        {
            if (!hasEnded)
            {
                if (++count > speed)
                {
                    count = 0;
                    current.X += width;
                    if (current.X >= maxWidth)
                    {
                        current.X = startX;
                        current.Y += height;
                    }
                    if (current.Y >= maxHeight)
                    {
                        if (loop)
                        {
                            current.X = startX;
                            current.Y = startY;
                        } else
                        {
                            hasEnded = true;
                        }
                    }
                }
            }
        }

        public void Reset()
        {
            this.hasEnded = false;
            current.X = startX;
            current.Y = startY;
        }

        public Rectangle GetRectangle()
        {
            return current;
        }

    }
}
