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
            images.AddImage("tile_sheet", content.Load<Texture2D>("TILESHEET128X128"));
            images.AddImage("grass", content.Load<Texture2D>("grass"));
            images.AddImage("interface", content.Load<Texture2D>("interface"));
            images.AddImage("powerbar", content.Load<Texture2D>("powerbar"));
            images.AddImage("healthbar", content.Load<Texture2D>("healthbar"));
            images.AddImage("gris", content.Load<Texture2D>("gris"));
            images.AddImage("player", content.Load<Texture2D>("player"));
            images.AddImage("background", content.Load<Texture2D>("Background"));
            images.AddImage("trees", content.Load<Texture2D>("Trees"));
            images.AddImage("box", content.Load<Texture2D>("block"));
            images.AddImage("mygga 128x128", content.Load<Texture2D>("mygga 128x128"));

            images.AddImage("stick", content.Load<Texture2D>("stick"));

            //Menu
            //images.AddImage("play", content.Load<Texture2D>("PLAY"));
            //images.AddImage("quit", content.Load<Texture2D>("QUIT"));
            //images.AddImage("help", content.Load<Texture2D>("HELP"));

            //particles
            images.AddImage("star", content.Load<Texture2D>("star"));
            images.AddImage("diamond", content.Load<Texture2D>("diamond"));
            images.AddImage("circle", content.Load<Texture2D>("circle"));
            images.AddImage("circle1", content.Load<Texture2D>("circle1"));
            images.AddImage("circle2", content.Load<Texture2D>("circle2"));
            images.AddImage("circle3", content.Load<Texture2D>("circle3"));
            images.AddImage("circlebig", content.Load<Texture2D>("circlebig"));
            images.AddImage("circlebig1", content.Load<Texture2D>("circlebig1"));
            images.AddImage("smoke", content.Load<Texture2D>("smoke"));

            tiles.AddTile(new Tile(0, 0, new Rectangle(64, 0, 64, 64), true));
            tiles.AddTile(new Tile(1, 0, new Rectangle(0, 0, 128, 64), true));
            tiles.AddTile(new Tile(2, 0, new Rectangle(0, 0, 64, 64), true));
            tiles.AddTile(new Tile(4, 0, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(5, 0, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(1, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(2, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(3, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(4, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(5, 1, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(4, 2, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(5, 2, new Rectangle(0, 0, 128, 128), true));
        }

    }
}
