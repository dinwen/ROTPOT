using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svennebanan;

namespace Rotpot.src.level.entities
{
    public class EntityStick : Entity
    {
        protected Vector2 velocity;
        protected int duration;
        public Vector2 size;
        public Rectangle getBounds;


        public EntityStick(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(600, 660);
            velocity = new Vector2(0, 3);

            size = new Vector2(128, 128);

        }
        public override void Update(GameTime gameTime)
        {
            if (--duration <= 0)
            {
                Remove();
            }
            position += velocity;

            if (GetDistance(level.GetPlayer().GetPosition()) < 100)
            {
                level.GetPlayer().Damage(10);
                Remove();
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("stick"), position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.05f);
        }
    }
}
