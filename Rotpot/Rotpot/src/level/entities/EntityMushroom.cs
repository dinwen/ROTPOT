using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpelProjekt.src.utils;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    public class EntityMushroom : EntityLiving
    {

        public float pushForce, pushTimer;
        private Animation animation;
        public Rectangle mushroomRectangle;

        public EntityMushroom(Vector2 position)
        {
            pushTimer = 0;
            pushForce = 2.0f;

            width = 160;
            height = 96;

            animation = new Animation(7, 0, 0, width, height, 9 * width, height, false);

            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            health++;
            if (level.GetPlayer().GetBoundsBottom().Intersects(GetBoundsFull()) && level.GetPlayer().GetVelocity().Y > 0)
            {
                level.resourceManager.audio.GetSound(13).Play();
                level.GetPlayer().SetVelocity(new Vector2(0, -40));
                animation.Reset();
            }
            else pushTimer = 0;
            if (!animation.hasEnded)
            {
                animation.Update();
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (!animation.hasEnded) batch.Draw(level.resourceManager.images.GetImage("svamp tilesheet 160x96"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.45f);
            else
            {
                batch.Draw(level.resourceManager.images.GetImage("svamp tilesheet 160x96"), position, new Rectangle(0, 0, width, height), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.45f);
            }
        }

    }
}
