using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.gui
{
    class MainMenu
    {

        private ResourceManager res;

        public MainMenu(ResourceManager res)
        {
            this.res = res;
        }

        public MainMenu()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(res.images.GetImage("background"), new Vector2(0, 0));
        }

    }
}
