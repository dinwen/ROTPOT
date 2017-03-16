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
    public class EntityPlayer : EntityLiving
    {
       
        public EntityPlayer()
        {
            health = 240;
            //strength value 346 max (Size)
        }

        public override void Update(GameTime gameTime)
        {

            if(health == 0)
            {

            }
            
        }

        public override void Draw(SpriteBatch batch)
        {

        }

    }
}
