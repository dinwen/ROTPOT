﻿using Microsoft.Xna.Framework;
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

        public void LoadLevel(string levelPath)
        {
            levelLoader = new LevelLoader(resourceManager, "Content/levels/level11.txt");
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
