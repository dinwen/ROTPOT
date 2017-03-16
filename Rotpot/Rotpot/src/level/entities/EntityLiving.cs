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

        public float GetHealth()
        {
            return health;
        }

        public float GetStrength()
        {
            return strength;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch batch)
        {

        }

    }
}
