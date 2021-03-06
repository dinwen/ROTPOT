﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svennebanan.utils;

namespace Svennebanan
{
    public class ResourceManager
    {
        public static SpriteFont font;
        public ImageHandler images;
        public TileHandler tiles;
        public AudioHandler audio;

        public ResourceManager()
        {
            images = new ImageHandler();
            tiles = new TileHandler();
            audio = new AudioHandler();
        }

        public void LoadContent(ContentManager content)
        {
            images.AddImage("Play", content.Load<Texture2D>("PLAY"));
            images.AddImage("Help", content.Load<Texture2D>("HELP"));
            images.AddImage("Options", content.Load<Texture2D>("OPTIONS"));
            images.AddImage("Quit", content.Load<Texture2D>("QUIT"));
            images.AddImage("LongJumpSign", content.Load<Texture2D>("LONGJUMPSign"));
            images.AddImage("DashSign", content.Load<Texture2D>("DashSign"));
            images.AddImage("Sign", content.Load<Texture2D>("skylt 192x192"));
            images.AddImage("DoubleSign", content.Load<Texture2D>("DoubleSign"));
            images.AddImage("WADSign", content.Load<Texture2D>("WADSign"));
            images.AddImage("WarningSign", content.Load<Texture2D>("WarningSign"));
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
            images.AddImage("leaf", content.Load<Texture2D>("leaves64x64"));
            images.AddImage("svamp tilesheet 160x96", content.Load<Texture2D>("svamp tilesheet 160x96"));
            images.AddImage("summoner", content.Load<Texture2D>("summoner"));
            images.AddImage("ExitSign", content.Load<Texture2D>("ExitSign"));
            images.AddImage("gem", content.Load<Texture2D>("gem"));

            images.AddImage("stick", content.Load<Texture2D>("stick"));

            //Menu
            //images.AddImage("play", content.Load<Texture2D>("PLAY"));
            //images.AddImage("quit", content.Load<Texture2D>("QUIT"));
            //images.AddImage("help", content.Load<Texture2D>("HELP"));

            //particles
            images.AddImage("star", content.Load<Texture2D>("particle 16x16"));
            images.AddImage("diamond", content.Load<Texture2D>("diamond"));
            images.AddImage("circle", content.Load<Texture2D>("circle"));
            images.AddImage("circle1", content.Load<Texture2D>("circle1"));
            images.AddImage("circle2", content.Load<Texture2D>("circle2"));
            images.AddImage("circle3", content.Load<Texture2D>("circle3"));
            images.AddImage("circlebig", content.Load<Texture2D>("circlebig"));
            images.AddImage("circlebig1", content.Load<Texture2D>("circlebig1"));
            images.AddImage("smoke", content.Load<Texture2D>("smoke"));
            images.AddImage("particle", content.Load<Texture2D>("particle 16x16"));

            //tiles
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
            tiles.AddTile(new Tile(1, 2, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(2, 2, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(3, 2, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(4, 2, new Rectangle(0, 0, 128, 128), true));
            tiles.AddTile(new Tile(5, 2, new Rectangle(0, 0, 128, 128), true));

            //sounds
            audio.AddAudio(0, content.Load<SoundEffect>("fly"));
            audio.AddAudio(1, content.Load<SoundEffect>("myggadmg"));
            audio.AddAudio(2, content.Load<SoundEffect>("myggadmg1"));
            audio.AddAudio(3, content.Load<SoundEffect>("myggadmg2"));
            audio.AddAudio(4, content.Load<SoundEffect>("pigmovementshort"));
            audio.AddAudio(5, content.Load<SoundEffect>("pigdmg1"));
            audio.AddAudio(6, content.Load<SoundEffect>("pigdie"));
            audio.AddAudio(7, content.Load<SoundEffect>("pinmovement"));
            audio.AddAudio(8, content.Load<SoundEffect>("pindash"));
            audio.AddAudio(9, content.Load<SoundEffect>("pinlanding2"));
            audio.AddAudio(10, content.Load<SoundEffect>("pinjump"));
            audio.AddAudio(11, content.Load<SoundEffect>("pindeath"));
            audio.AddAudio(12, content.Load<SoundEffect>("coinsound"));
            audio.AddAudio(13, content.Load<SoundEffect>("mushroom"));

            font = content.Load<SpriteFont>("Score");
        }

    }
}
