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
    public class EntitySign : Entity
    {

        int signId;

        public EntitySign(Vector2 position, int signId)
        {
            this.position = position;
            this.signId = signId;


        }




        public override void Draw(SpriteBatch batch)
        {
            EntityPlayer player = level.GetPlayer();

            batch.Draw(level.resourceManager.images.GetImage("Sign"), position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);

            if(player.GetDistance(position) <= 500 && signId == 1)
            {
                batch.Draw(level.resourceManager.images.GetImage("WASDSign"), new Vector2(position.X, position.Y - 100), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
            }


        }


    }
}
