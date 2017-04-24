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
        private float rotation;

        private float GRAVITY = 0.2f;

        public EntityStick(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(600, 660);
            velocity = new Vector2(0, 5);

            size = new Vector2(128, 128);

        }
        public override void Update(GameTime gameTime)
        {
            rotation += 0.03f;
            velocity.Y += GRAVITY;

            if (--duration <= 0)
            {
                Remove();
            }
            position += velocity;

            if (GetDistance(new Vector2(level.GetPlayer().GetPosition().X + 64, level.GetPlayer().GetPosition().Y + 64)) < 100)
            {
                level.GetPlayer().Damage(10);
                level.GetPlayer().Knockback(this);
                Remove();
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("stick"), position, null, Color.White, rotation, new Vector2(64, 64), 1, SpriteEffects.None, 0.05f);
        }
    }
}
