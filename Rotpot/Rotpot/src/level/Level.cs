using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Svennebanan.utils;
using System.Collections.Generic;

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
        }

        public void Reset()
        {
            entities.Clear();
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(batch);
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                //batch.Draw(main.images.GetImage(100), tiles[i].position, tiles[i].texture, Color.White);
            }
        }

    }
}
