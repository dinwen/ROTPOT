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

        Vector2 startPos;
        float wobbleY;
        float wobbleTime;

        float wobbleRotation;
        float wobbleRotationTime;

        public EntityCoin(Vector2 position, int coinID, int value)
        {
            this.position = position * 128;
            startPos = position * 128;
            this.coinID = coinID;
            this.value = value;
        }

        public override void Update(GameTime gameTime)
        {
            if(gameTime.TotalGameTime.Milliseconds % 10 == 0) level.entityManager.AddEntity(level, new ParticleStar(new Vector2(position.X, position.Y + rdn.Next(128 + 10) - 128 / 2), new Color(255, 220, 200)));

            EntityPlayer player = level.GetPlayer();

            wobbleTime++;
            if (wobbleTime % 100 == 0) wobbleTime = 0;

            wobbleRotationTime++;
            if (wobbleRotationTime % 50 == 0) wobbleRotationTime = 0;

            wobbleY = (float)Math.Sin(wobbleTime / 50 * Math.PI) * 35;
            wobbleRotation = (float)Math.Sin(wobbleRotationTime / 25 * Math.PI) * 0.2f;
            position.Y = startPos.Y + wobbleY;

            if(GetDistance(player.GetPosition() + new Vector2(player.width / 2, player.height / 2)) <= 100)
            {
                level.resourceManager.audio.GetSound(12).Play(0.7f, 0, 0);
                Main.score += value;
                Remove();
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("gem"), position, null, Color.White, wobbleRotation, new Vector2(64, 64), 1, SpriteEffects.None, 0.4f);
        }
    }
}
