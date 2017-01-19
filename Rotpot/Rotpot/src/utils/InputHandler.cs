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
        public static bool viking_left;
        public static bool viking_right;
        public static bool viking_jump;
        public static bool viking_sprint;
        public static bool viking_attack;

        public static bool alien_left;
        public static bool alien_right;
        public static bool alien_jump;
        public static bool alien_sprint;
        public static bool alien_attack;

        public static bool escape;

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                viking_right = true;
            }
            else
            {
                viking_right = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                viking_left = true;
            }
            else
            {
                viking_left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                viking_jump = true;
            }
            else
            {
                viking_jump = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                viking_sprint = true;
            }
            else
            {
                viking_sprint = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                viking_attack = true;
            }
            else
            {
                viking_attack = false;
            }




            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                alien_right = true;
            }
            else
            {
                alien_right = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                alien_left = true;
            }
            else
            {
                alien_left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                alien_jump = true;
            }
            else
            {
                alien_jump = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.RightShift))
            {
                alien_sprint = true;
            }
            else
            {
                alien_sprint = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.RightControl))
            {
                alien_attack = true;
            }
            else
            {
                alien_attack = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                escape = true;
            }
            else
            {
                escape = false;
            }
        }

    }
}
