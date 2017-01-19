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

        public Dictionary<int, Texture2D> images = new Dictionary<int, Texture2D>();

        public void AddImage(int id, Texture2D image)
        {
            images.Add(id, image);
        }

        public Texture2D GetImage(int id)
        {
            return images[id];
        }

    }
}
