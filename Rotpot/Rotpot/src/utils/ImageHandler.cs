using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class ImageHandler
    {

        private Dictionary<string, Texture2D> images = new Dictionary<string, Texture2D>();

        public void AddImage(string name, Texture2D image)
        {
            images.Add(name, image);
        }

        public Texture2D GetImage(string name)
        {
            return images[name];
        }

    }
}
