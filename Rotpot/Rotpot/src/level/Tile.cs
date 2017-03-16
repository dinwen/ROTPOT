using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class Tile
    {

        public Vector2 position;
        public Rectangle texturePosition;
        public bool solid;

        public Tile(int texPosX, int texPosY, bool solid)
        {
            this.texturePosition = new Rectangle(texPosX * 128, texPosY * 128, 128, 128);
            this.solid = solid;
        }

        public Tile(Vector2 position, Tile tile)
        {
            this.position = position;
            this.texturePosition = tile.texturePosition;
            this.solid = tile.solid;
        }

    }
}
