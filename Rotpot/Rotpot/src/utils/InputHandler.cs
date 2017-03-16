using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class InputHandler
    {
        public static bool left;
        public static bool right;
        public static bool jump;
        public static bool sprint;
        public static bool attack;
        

        public static bool escape;

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                right = true;
            }
            else
            {
                right = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                left = true;
            }
            else
            {
                left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                jump = true;
            }
            else
            {
                jump = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                sprint = true;
            }
            else
            {
                sprint = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
        }

    }
}
