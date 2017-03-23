using Microsoft.Xna.Framework;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Rotpot.src.level.entities
{
    public class Particle : Entity
    {

        protected Random random = new Random();
        protected Vector2 velocity;

        public Particle(Vector2 position)
        {
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            
        }

    }
}
