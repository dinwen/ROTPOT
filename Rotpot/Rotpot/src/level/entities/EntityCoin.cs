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
    public class EntityCoin : Entity
    {
        int coinID;
        int value;
       

        

        

        public EntityCoin(Vector2 position, int coinID, int value)
        {
            this.position = position * 128;
            this.coinID = coinID;
            this.value = value;
        }

        public override void Update(GameTime gameTime)
        {
            EntityPlayer player = level.GetPlayer();
            


            if(player.GetDistance(position) <= 50)
            {
                Main.score += value;
                Remove();
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("gem"), position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
        }
    }
}
