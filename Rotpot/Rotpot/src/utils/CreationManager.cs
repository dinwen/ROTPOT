using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.utils
{
    public class CreationManager
    {

        private Level level;

        public CreationManager(Level level)
        {
            this.level = level;
        }

        public void CreateEntity(Entity e, int id)
        {
            level.entityManager.AddEntity(level, e, id);
        }

        public void Update()
        {

        }

    }
}
