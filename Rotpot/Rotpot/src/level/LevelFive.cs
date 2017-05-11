using Microsoft.Xna.Framework;
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

        public LevelFive(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/Level5.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(128 * 2, 128 * 68.0f)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 26, 128 * 73.25f)));
            entityManager.AddEntity(this, new EntityBox(new Vector2(128 * 272, 128 * 64)));
            entityManager.AddEntity(this, new EntitySummoner(new Vector2(128 * 239, 128 * 64)));
            entityManager.AddEntity(this, new EntitySign(new Vector2(128 * 216, 128 * 63.5f), 5));

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            //if (GetPlayer().GetPosition().X > 128 * 25 && --stickCooldown <= 0)
            //{
            //    if (GetPlayer().moving)
            //    {
            //        if (GetPlayer().direction == -1)
            //        {
            //            entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 1000) - 800, GetPlayer().GetPosition().Y - 2400)));
            //            stickCooldown = 50;
            //        }
            //        else if (GetPlayer().direction == 1)
            //        {
            //            entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-1000, 500) + 800, GetPlayer().GetPosition().Y - 2400)));
            //            stickCooldown = 50;
            //        }
            //    }
            //    else
            //    {
            //        entityManager.AddEntity(this, new EntityStick(new Vector2(GetPlayer().GetPosition().X + random.Next(-500, 500), GetPlayer().GetPosition().Y - 2400)));
            //        stickCooldown = 50;
            //    }
            //}
            base.Update(gameTime);
        }

    }
}
