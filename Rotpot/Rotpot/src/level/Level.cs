using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rotpot;
using Rotpot.src.gui;
using Rotpot.src.level;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan.utils;
using System;
using System.Collections.Generic;

namespace Svennebanan
{
    public class Level
    {

        public float width, height;
      
        protected LevelLoader levelLoader;
        public HUD hud;

        protected static Random random = new Random();

        //Managers
        public ResourceManager resourceManager;
        public EntityManager entityManager;
        public CreationManager creationManager;
        public InputHandler inputHandler;

        //List of all the loaded tiles
        public List<Tile> tiles = new List<Tile>();

        //Backgrounds
        protected Vector2 background1, background2;
        protected Vector2 background3, background4;

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            hud = new HUD(resources, this);

            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);
        }

        public void ClearLevel()
        {
            Entity stepper = Entity.firstEntity;
            if (stepper != null)
            {
                stepper.Remove();
                while (stepper.nextEntity != null)
                {
                    stepper = stepper.nextEntity;
                    stepper.Remove();
                }
            }
        }

        public void ChangeLevel(int levelID)
        {
            if (levelID == 1)
            {
                Main.level = new LevelOne(resourceManager);
            }
            else if (levelID == 2)
            {
                Main.level = new LevelTwo(resourceManager);
            }
            else if (levelID == 3)
            {
                Main.level = new LevelThree(resourceManager);
            }
            else if (levelID == 4)
            {
                Main.level = new LevelFour(resourceManager);
            }
            else if (levelID == 5)
            {
                Main.level = new LevelFive(resourceManager);
            }
            else if(levelID == 6)
            {
                levelID = 1;
                Main.state = Main.STATE.Menu;
            } 

        }

        public void LoadLevel(string levelPath)
        {
            levelLoader = new LevelLoader(resourceManager, levelPath);
            tiles = levelLoader.GetLevelTiles();
            Reset();
        }

        public void Reset()
        {
            Entity stepper = Entity.firstEntity;
            if (stepper != null)
            {
                stepper.Reset();
                while (stepper.nextEntity != null)
                {
                    stepper = stepper.nextEntity;
                    stepper.Reset();
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);

            Main.camera.Update();
            background1 = new Vector2((int)((Main.camera.Position.X) / 1920) * 1920, Main.camera.Position.Y);
            background2 = new Vector2((int)((Main.camera.Position.X) / 1920 + 1) * 1920, Main.camera.Position.Y);
            background3 = new Vector2((int)((Main.camera.Position.X * 1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5), Main.camera.Position.Y);
            background4 = new Vector2((int)((Main.camera.Position.X * 1.2f) / 1920) * 1920 - (Main.camera.Position.X / 5) + 1920, Main.camera.Position.Y);
            hud.Update(gameTime);
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

            EntityPlayer player = GetPlayer();
            if (player != null)
            {
                foreach (Tile t in tiles)
                {
                    float dir = player.GetDistance(t.position);
                    if (dir < 1920) batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);
                }

                hud.Draw(batch);
            }
        }

    }
}
