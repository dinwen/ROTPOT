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
    class LevelThree : Level
    {

        public LevelThree(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/Level3.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(128 * 3, 128 * 87)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 63, 128 * 98.25f)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 74, 128 * 88.25f)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 85, 128 * 78.25f)));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(63, 86), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(74, 76), 1, 50));
            entityManager.AddEntity(this, new EntityCoin(new Vector2(86, 66), 1, 50));
         

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

    }
}
