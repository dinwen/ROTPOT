using Microsoft.Xna.Framework;
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
            images.AddImage("tile_sheet", content.Load<Texture2D>("TILESHEET128X128b"));
            images.AddImage("grass", content.Load<Texture2D>("grass"));
            images.AddImage("interface", content.Load<Texture2D>("interface"));
            images.AddImage("powerbar", content.Load<Texture2D>("powerbar"));
            images.AddImage("healthbar", content.Load<Texture2D>("healthbar"));
            images.AddImage("gris", content.Load<Texture2D>("gris"));
            images.AddImage("player", content.Load<Texture2D>("player"));
            images.AddImage("background", content.Load<Texture2D>("Background"));

            tiles.AddTile(new Tile(0, 0, new Rectangle(64, 0, 64, 64), true));
            tiles.AddTile(new Tile(1, 0, new Rectangle(0, 0, 128, 64), true));
            tiles.AddTile(new Tile(2, 0, new Rectangle(0, 0, 64, 64), true));
            tiles.AddTile(new Tile(3, 0, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(4, 0, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(0, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(1, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(2, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(3, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(4, 1, new Rectangle(0, 0, 128, 128), true));
        }

    }
}
