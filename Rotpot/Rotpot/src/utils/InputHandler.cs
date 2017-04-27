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

        public static bool releaseJump = false;
        

        public static bool escape;
        public static bool shift;

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

            if (Keyboard.GetState().IsKeyDown(Keys.S))
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

            if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if(!releaseJump) attack = true;
            }
            else
            {
                releaseJump = false;
                attack = false;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                shift = true;
            }
            else
            {
                shift = false;
            }
        }

    }
}
