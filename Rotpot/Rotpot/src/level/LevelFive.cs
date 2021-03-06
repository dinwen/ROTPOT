﻿using Microsoft.Xna.Framework;
using Rotpot.src.level.entities;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level
{
    class LevelFive : Level
    {

        private bool enemiesSpawned = false;
        private int stickCooldown;

        public LevelFive(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/Level5.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(128 * 2, 128 * 68.0f)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 26, 128 * 73.25f)));
            entityManager.AddEntity(this, new EntityBox(new Vector2(128 * 272, 128 * 64)));
            entityManager.AddEntity(this, new EntitySummoner(new Vector2(128 * 239, 128 * 64)));
            entityManager.AddEntity(this, new EntitySign(new Vector2(128 * 216, 128 * 63.5f), 5));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(27, 61), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(51, 56), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(75, 64), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(93, 57), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(169, 59), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(224, 70), 1, 50));


            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (GetPlayer().GetPosition().X > 128 * 16 && --stickCooldown <= 0)
            {
                if(GetPlayer().GetPosition().X > 128 * 30 && !enemiesSpawned)
                {
                    enemiesSpawned = true;
                    for (int i = 0; i < 10; i++)
                    {
                        entityManager.AddEntity(this, new EntityMygga(new Vector2(128 * 30, 128 * 56), 128 * 210));
                    }
                }

                if (GetPlayer().moving)
                {
                    if (GetPlayer().direction == -1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 1000) - 800, GetPlayer().GetPosition().Y - 2400)));
                        stickCooldown = 50;
                    }
                    else if (GetPlayer().direction == 1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-1000, 500) + 800, GetPlayer().GetPosition().Y - 2400)));
                        stickCooldown = 50;
                    }
                }
                else
                {
                    entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 500), GetPlayer().GetPosition().Y - 2400)));
                    stickCooldown = 50;
                }
            }
            base.Update(gameTime);
        }

    }
}
