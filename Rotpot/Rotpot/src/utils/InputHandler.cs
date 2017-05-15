using Microsoft.Xna.Framework;
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
        public static bool releaseShift = false;

        
        

        public static bool escape;
        public static bool shift;

        public void Update()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

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
                if(!capabilities.IsConnected) releaseJump = false;
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


            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (state.IsConnected && state.ThumbSticks.Left.X <= -0.5f)
                {
                    left = true;
                }
                else
                {
                    left = false;
                }
                if (state.IsConnected && state.ThumbSticks.Left.X >= 0.5f)
                {
                    right = true;
                }
                else
                {
                    right = false;
                }
                if (state.IsConnected && state.Buttons.A == ButtonState.Pressed)
                {
                    if (!releaseJump) attack = true;
                }
                else
                {
                    releaseJump = false;
                    attack = false;
                }
                if (state.IsConnected && state.Buttons.B == ButtonState.Pressed)
                {
                    if(!releaseShift) shift = true;
                }
                else
                {
                    releaseShift = false;
                    shift = false;
                }
                

            }
        }

    }
}
