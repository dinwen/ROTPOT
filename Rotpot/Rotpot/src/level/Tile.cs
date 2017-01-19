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
        public Rectangle texture;
        private Rectangle collision;
        private bool solid;

        public static Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

        public Tile(bool solid, Rectangle texture)
        {
            this.solid = solid;
            this.texture = texture;
        }

        public Tile(int x, int y, Tile tile)
        {
            this.position = new Vector2(x, y);
            this.solid = tile.solid;
            this.texture = tile.texture;
            this.collision = new Rectangle(x, y, 32, 32);
        }

        public static void AddTile(int id, Tile tile)
        {
            tiles.Add(id, tile);
        }

        public Rectangle GetBounds()
        {
            return collision;
        }

    }
}
