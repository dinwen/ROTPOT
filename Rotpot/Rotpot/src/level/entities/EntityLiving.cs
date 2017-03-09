using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    public class EntityLiving : Entity
    {
        protected float health;
        protected float strength;
        protected float movementSpeed;



        public EntityLiving()
        {

        }

        public void Move(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Damage(float damage)
        {
            health -= damage;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch)
        {

        }

    }
}
