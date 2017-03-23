﻿using Microsoft.Xna.Framework;
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

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
            levelLoader = new LevelLoader(resources, "Content/levels/Level11.txt");
            tiles = levelLoader.GetLevelTiles();

            
            entityManager = new EntityManager(this);
            creationManager = new CreationManager(this);

            entityManager.AddEntity(this, new EntityPlayer(), 0);
            hud = new HUD(resources, this);
            entityManager.AddEntity(this, new EntityPig(new Vector2(-100, -125)), 1);
        }

        public void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);
        }

      
        public EntityPlayer GetPlayer()
        {
            return (EntityPlayer)entityManager.GetEntity(0);
        }
        public void Draw(SpriteBatch batch)
        {
            entityManager.Draw(batch);
            hud.Draw(batch);

            foreach (Tile t in tiles)
            {
                
                batch.Draw(resourceManager.images.GetImage("tile_sheet"), t.position, t.texturePosition, Color.White);
            }
        }

    }
}
