using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan.utils;
using System.Collections.Generic;

namespace Svennebanan
{
    public class Level
    {

        private LevelLoader levelLoader;

        //Managers
        public ResourceManager resourceManager;
        public EntityManager entityManager;
        public CreationManager creationManager;

        public List<Tile> tiles = new List<Tile>();

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/TestLevelll.txt");
            tiles = levelLoader.GetLevelTiles();

            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);
            creationManager.CreateEntity(new EntityPlayer(new Vector2(100, 100)), 0);
        }

        public void Update()
        {
            entityManager.Update();
        }

        public void Draw(SpriteBatch batch)
        {
            entityManager.Draw(batch);

            foreach (Tile t in tiles)
            {
                batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White);
            }
        }

    }
}
