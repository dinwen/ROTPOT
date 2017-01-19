using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan.gui
{
    public class Button
    {
        public bool trigger;
        private Vector2 position;
        private int width, height;
        private int textureID;
        private Main main;


        public Button(Vector2 position, int width, int height, int textureID, Main main)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.main = main;
            this.textureID = textureID;
        }

        public void Update()
        {
            if ((Mouse.GetState().X / 2 >= position.X && Mouse.GetState().X / 2 <= position.X + width) && (Mouse.GetState().Y / 2 >= position.Y && Mouse.GetState().Y / 2 <= position.Y + height))
            {
                if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    trigger = true;
                }
                else
                {
                    trigger = false;
                }
            }
            else
            {
                trigger = false;
            }

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(main.images.GetImage(textureID), position, Color.White);
        }
    }
}
