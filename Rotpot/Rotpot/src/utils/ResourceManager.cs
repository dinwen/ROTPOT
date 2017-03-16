using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class ResourceManager
    {

        public ImageHandler images;
        public TileHandler tiles;

        public ResourceManager()
        {
            images = new ImageHandler();
            tiles = new TileHandler();
        }

        public void LoadContent(ContentManager content)
        {
            images.AddImage("tile_sheet", content.Load<Texture2D>("TILESHEET128X128"));
            images.AddImage("grass", content.Load<Texture2D>("grass"));
            images.AddImage("interface", content.Load<Texture2D>("interface"));
            images.AddImage("powerbar", content.Load<Texture2D>("powerbar"));
            images.AddImage("healthbar", content.Load<Texture2D>("healthbar"));
            images.AddImage("gris", content.Load<Texture2D>("gris"));
            
            tiles.AddTile(new Tile(0, 0, true));
            tiles.AddTile(new Tile(1, 0, true));
            tiles.AddTile(new Tile(2, 0, true));
            tiles.AddTile(new Tile(3, 0, true));
        }

    }
}
