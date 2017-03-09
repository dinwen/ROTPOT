using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class Entity
    {

        public Entity nextEntity;
        public static Entity firstEntity;
        public int id;

        protected Vector2 position;
        protected Level level;

        private bool remove = false;

        public void Init(Level level)
        {
            this.level = level;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

        public void Remove()
        {
            remove = true;
        }

        public bool IsRemoved()
        {
            return remove;
        }

    }
}
