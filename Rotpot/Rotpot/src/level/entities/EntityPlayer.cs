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
            moving = new Animation(5, 0, 0, 128, 128, 10, 1, true);
            this.position = position;
        }

        public override void Update()
        {
            moving.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("gris"), position, moving.GetRectangle(), Color.White);

        }

    }
}
