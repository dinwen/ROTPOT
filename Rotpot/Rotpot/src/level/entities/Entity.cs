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

        protected static Random rdn = new Random();


        public void Init(Level level)
        {
            this.level = level;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public float GetDistance(Vector2 secondPosition)
        {
            float distance = Vector2.Distance(position, secondPosition);
            return distance;
        }

        public float GetDirection(Vector2 secondPosition)
        {
            Vector2 delta = secondPosition - position;
            return (float) Math.Atan2(delta.Y, delta.X);
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
