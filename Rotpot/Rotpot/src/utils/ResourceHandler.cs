using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class ResourceHandler
    {

        public ImageHandler images;
        public TileHandler tiles;

        public ResourceHandler()
        {
            images = new ImageHandler();
            tiles = new TileHandler();
        }

        public void LoadContent(ContentManager content)
        {
            images.AddImage("tile_sheet", content.Load<Texture2D>("tiles"));

            tiles.AddTile(new Tile(0, 0, true));
            tiles.AddTile(new Tile(1, 0, true));
            tiles.AddTile(new Tile(2, 0, true));
            tiles.AddTile(new Tile(3, 0, true));
            tiles.AddTile(new Tile(4, 0, true));
            tiles.AddTile(new Tile(5, 0, true));
            tiles.AddTile(new Tile(0, 1, true));
            tiles.AddTile(new Tile(1, 1, true));
            tiles.AddTile(new Tile(2, 1, true));
            tiles.AddTile(new Tile(3, 1, true));
            tiles.AddTile(new Tile(4, 1, true));
            tiles.AddTile(new Tile(5, 1, true));
            tiles.AddTile(new Tile(0, 2, true));
            tiles.AddTile(new Tile(1, 2, true));
            tiles.AddTile(new Tile(2, 2, true));
        }

    }
}
