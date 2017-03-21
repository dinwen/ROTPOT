using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Rotpot.src.gui;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan.utils;
using System.Collections.Generic;

namespace Svennebanan
{
    public class Level
    {

        private LevelLoader levelLoader;
        public HUD hud;
        

        //Managers
        public ResourceManager resourceManager;
        public EntityManager entityManager;
        public CreationManager creationManager;
        public InputHandler inputHandler;

        public List<Tile> tiles = new List<Tile>();

        private Vector2 bg1, bg2;

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/Level11.txt");
            tiles = levelLoader.GetLevelTiles();

            
            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);

            entityManager.AddEntity(this, new EntityPlayer(), 0);
            hud = new HUD(resources, this);

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
        }

        public void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);

            Main.camera.Update();
            bg1 = new Vector2((int)((Main.camera.Position.X) / 1920) * 1920, Main.camera.Position.Y);
            bg2 = new Vector2((int)((Main.camera.Position.X) / 1920 + 1) * 1920, Main.camera.Position.Y);
        }

        public EntityPlayer GetPlayer()
        {
            return (EntityPlayer) entityManager.GetEntity(0);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(resourceManager.images.GetImage("background"), bg1, Color.White);
            batch.Draw(resourceManager.images.GetImage("background"), bg2, Color.White);

            entityManager.Draw(batch);

            foreach (Tile t in tiles)
            {
                batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White);
            }

            hud.Draw(batch);
        }

    }
}
