using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Svennebanan.utils;
using System.Collections.Generic;

namespace Svennebanan
{
    public class Level
    {

        public Main main;
        public ResourceHandler resources;
        private LevelLoader levelLoader;

        public List<Entity> entities = new List<Entity>();
        public List<Tile> tiles = new List<Tile>();

        public Level(Main main, ResourceHandler resources)
        {
            this.main = main;
            this.resources = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/test.txt");
            tiles = levelLoader.GetLevelTiles();
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

            foreach (Tile t in tiles)
            {
                batch.Draw(resources.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White);
            }
        }

    }
}
