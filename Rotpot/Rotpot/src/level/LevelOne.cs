using Microsoft.Xna.Framework;
using Rotpot.src.gui;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level
{
    class LevelOne : Level
    {

        int stickCooldown = 60;

        public LevelOne(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/level11.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(2 * 128, 47 * 128)));
            entityManager.AddEntity(this, new EntityBox(new Vector2(226 * 128, 40 * 128)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));
            entityManager.AddEntity(this, new EntityMygga(new Vector2(-100, 2600)));

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (--stickCooldown <= 0)
            {
                if (GetPlayer().moving)
                {
                    if (GetPlayer().direction == -1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 1000) - 800, GetPlayer().GetPosition().Y - 700)));
                        stickCooldown = 50;
                    }
                    else if (GetPlayer().direction == 1)
                    {
                        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-1000, 500) + 800, GetPlayer().GetPosition().Y - 700)));
                        stickCooldown = 50;
                    }
                }
                else
                {
                    entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 500), GetPlayer().GetPosition().Y - 700)));
                    stickCooldown = 50;
                }
            }
        }

    }
}
