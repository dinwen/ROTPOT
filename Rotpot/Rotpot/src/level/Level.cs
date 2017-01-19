using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Svennebanan.level.entities;
using Svennebanan.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class Level
    {

        public int width, height;

        public Main main;
        private LevelLoader levelLoader;

        public List<Entity> entities = new List<Entity>();
        public List<Tile> tiles = new List<Tile>();

        public int winner = 0;
        public int gameOverCooldown = 60 * 5;

        public Level(Main main)
        {
            this.main = main;
            this.levelLoader = new LevelLoader("Content/levels/daniel.txt");
            this.tiles = levelLoader.loadedTiles;

            AddEntity(new PlayerViking(new Vector2(100, 100)));
            AddEntity(new PlayerAlien(new Vector2(800, 100)));
        }

        public void AddEntity(Entity e)
        {
            entities.Add(e);
            e.Init(this);
        }

        public void Update()
        {
            for(int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
                if (entities[i].IsRemoved())
                {
                    entities.RemoveAt(i);
                }
            }

            if(winner != 0)
            {
                if(--gameOverCooldown <= 0)
                {
                    gameOverCooldown = 60 * 5;
                    Reset();
                    Main.state = Main.STATE.menu;
                    main.music.Stop();
                    main.music = main.sounds.GetSound(101).CreateInstance();
                    main.music.IsLooped = true;
                    main.music.Play();
                }
            }
        }

        public void Reset()
        {
            entities.Clear();
            winner = 0;
            AddEntity(new PlayerViking(new Vector2(100, 100)));
            AddEntity(new PlayerAlien(new Vector2(800, 100)));
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(main.images.GetImage(50), new Vector2(0, 0), Color.White);
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(batch);
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                batch.Draw(main.images.GetImage(100), tiles[i].position, tiles[i].texture, Color.White);
            }
        }

    }
}
