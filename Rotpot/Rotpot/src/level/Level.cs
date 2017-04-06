using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Rotpot.src.gui;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan.utils;
using System;
using System.Collections.Generic;

namespace Svennebanan
{
    public class Level
    {

        private LevelLoader levelLoader;
        public HUD hud;

        protected static Random rdn = new Random();
        int stickCooldown = 60;


        //Managers
        public ResourceManager resourceManager;
        public EntityManager entityManager;
        public CreationManager creationManager;
        public InputHandler inputHandler;

        public List<Tile> tiles = new List<Tile>();

        private Vector2 background1, background2;
        private Vector2 background3, background4;

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/Level2.txt");
            tiles = levelLoader.GetLevelTiles();
            
            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(100, 100)));
            entityManager.AddEntity(this, new EntityBox(new Vector2(469 * 128, 14 * 128)));
            entityManager.AddEntity(this, new EntityPig(new Vector2(200, 100)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(100, 2600)));
            hud = new HUD(resources, this);

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
        }

        public void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);
            if (--stickCooldown <= 0)
            {
                if (GetPlayer().moving)
                {
                    if (GetPlayer().direction == -1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + rdn.Next(-500, 1000) - 1920, GetPlayer().GetPosition().Y - 700)));
                        stickCooldown = 200;
                    }
                    else if (GetPlayer().direction == 1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + rdn.Next(-1000, 500) + 1920, GetPlayer().GetPosition().Y - 700)));
                        stickCooldown = 200;
                    }
                }
                else
                {
                    entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + rdn.Next(-500, 500), GetPlayer().GetPosition().Y - 700)));
                    stickCooldown = 200;
                }
            }



            Main.camera.Update();
            background1 = new Vector2((int)((Main.camera.Position.X) / 1920) * 1920, Main.camera.Position.Y);
            background2 = new Vector2((int)((Main.camera.Position.X) / 1920 + 1) * 1920, Main.camera.Position.Y);
            background3 = new Vector2((int)((Main.camera.Position.X*1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5), Main.camera.Position.Y);
            background4 = new Vector2((int)((Main.camera.Position.X * 1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5) + 1920, Main.camera.Position.Y);
        }

        public EntityPlayer GetPlayer()
        {
            return (EntityPlayer) entityManager.GetEntity(0);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(resourceManager.images.GetImage("background"), background1, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background"), background2, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("trees"), background3, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.01f);
            batch.Draw(resourceManager.images.GetImage("trees"), background4, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.01f);


            entityManager.Draw(batch);

            foreach (Tile t in tiles)
            {
                batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);
            }

            hud.Draw(batch);
        }

    }
}
