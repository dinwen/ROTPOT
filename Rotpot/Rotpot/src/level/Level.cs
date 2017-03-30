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
        private Vector2 bg3, bg4;

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/Level2.txt");
            tiles = levelLoader.GetLevelTiles();

            
            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);

            entityManager.AddEntity(this, new EntityPlayer());
            entityManager.AddEntity(this, new EntityBox(new Vector2(132 * 128, 11 * 128)));
            entityManager.AddEntity(this, new EntityPig(new Vector2(9000, 100)));
            hud = new HUD(resources, this);

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
        }

        public void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);

            Main.camera.Update();
            bg1 = new Vector2((int)((Main.camera.Position.X) / 1920) * 1920, Main.camera.Position.Y);
            bg2 = new Vector2((int)((Main.camera.Position.X) / 1920 + 1) * 1920, Main.camera.Position.Y);
            bg3 = new Vector2((int)((Main.camera.Position.X*1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5), Main.camera.Position.Y);
            bg4 = new Vector2((int)((Main.camera.Position.X * 1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5) + 1920, Main.camera.Position.Y);
        }

        public EntityPlayer GetPlayer()
        {
            return (EntityPlayer) entityManager.GetEntity(0);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(resourceManager.images.GetImage("background"), bg1, Color.White);
            batch.Draw(resourceManager.images.GetImage("background"), bg2, Color.White);
            batch.Draw(resourceManager.images.GetImage("trees"), bg3, Color.White);
            batch.Draw(resourceManager.images.GetImage("trees"), bg4, Color.White);


            entityManager.Draw(batch);

            foreach (Tile t in tiles)
            {
                batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White);
            }

            hud.Draw(batch);
        }

    }
}
