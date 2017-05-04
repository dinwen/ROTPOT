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
    class LevelTwo : Level
    {

        public LevelTwo(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/Level2.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(128 * 3, 128 * 47)));
            entityManager.AddEntity(this, new EntitySign(new Vector2(128 * 32, 128 * 47.5f), 2));
            entityManager.AddEntity(this, new EntitySign(new Vector2(128 * 92, 128 * 47.5f), 3));
            entityManager.AddEntity(this, new EntitySign(new Vector2(128 * 104, 128 * 47.5f), 4));

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

    }
}
