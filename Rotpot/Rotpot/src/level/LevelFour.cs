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
    class LevelFour : Level
    {

        public LevelFour(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/Level4.txt");

            entityManager.AddEntity(this, new EntityPlayer(new Vector2(128 * 2, 128 * 68)));
            entityManager.AddEntity(this, new EntityMushroom(new Vector2(128 * 57, 128 * 71.25f)));
            entityManager.AddEntity(this, new EntityBox(new Vector2(128 * 260, 128 * 64f)));

            Main.camera.SetLevelSize(levelLoader.size.X * 128, levelLoader.size.Y * 128);
            width = levelLoader.size.X * 128;
            height = levelLoader.size.Y * 128;
            Reset();
        }

    }
}
