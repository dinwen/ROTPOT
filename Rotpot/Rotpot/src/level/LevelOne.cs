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
            LoadLevel("Content/levels/Level3.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(40 * 128, 87 * 128)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(63 * 128, 98.25f * 128)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(74 * 128, 88.25f * 128)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(85 * 128, 78.25f * 128)));

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (--stickCooldown <= 0)
            {
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
