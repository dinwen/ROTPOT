using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpelProjekt.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    public class EntityPlayer : EntityLiving
    {

        public Animation moving;

        public EntityPlayer(Vector2 position)
        {
            this.position = position;
        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch batch)
        {
        }

    }
}
