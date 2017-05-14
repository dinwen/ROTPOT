using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using Svennebanan.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.gui
{
    public class MainMenu
    {
        
        private ResourceManager res;
        private Button start;
        private Button help;
        private Button options;
        private Button quit;

      


        public MainMenu(ResourceManager res, Vector2 position, Level level)
        {
            this.res = res;


            start = new Button(new Vector2(1920 / 2 - 342 / 2, 1080 / (float)3.5 - 114 / (float)3.5), 342, 114, "Play", level);

            quit = new Button(new Vector2(1920 / 2 - 400 / 2, 1080 / (float)1.25 - 113 / (float)1.25), 400, 113, "Quit", level);

        }

        public MainMenu()
        {

        }

        public void Update()
        {
            start.Update();

            quit.Update();
            

            if (start.trigger)
            {
                Main.state = Main.STATE.Game;
                start.trigger = false;
            }

           

            if (quit.trigger)
            {
                Main.state = Main.STATE.Quit;
            }


        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(res.images.GetImage("background"), new Vector2(0, 0));
            start.Draw(batch);

            quit.Draw(batch);

        }

    }
}
