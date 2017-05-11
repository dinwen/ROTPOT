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
    class EntitySummoner : EntityLiving
    {

        private Animation animation;
        private Vector2 spawnPosition;

        private int direction = 0;
        private int movementCooldown = 60;

        public EntitySummoner(Vector2 position)
        {
            movementSpeed = 1;
            health = 1;
            strength = 1;

            this.position = position;
            this.spawnPosition = position;

            width = 384;
            height = 384;

            animation = new Animation(2, 0, 0, width, height, 7 * width, height, false);
        }

        public override void Update(GameTime gameTime)
        {
            if (!OnGround())
            {
                velocity.Y += GRAVITY;
            }

            if (--movementCooldown <= 0)
            {
                animation.Update();
            }

            if (level.GetPlayer().GetBoundsFull().Intersects(GetBoundsFull())) level.GetPlayer().Damage(100);

            if(animation.hasEnded)
            {
                movementCooldown = 30 + rdn.Next(100);
                Vector2 movement = new Vector2(0, 0);
                do
                {
                    movement.X = rdn.Next(2000) - 1000;
                } while (Vector2.Distance(position + movement, spawnPosition) > 800);

                position += movement;
                animation.Reset();

                if(GetDistance(level.GetPlayer().GetPosition()) < 1500) level.entityManager.AddEntity(level, new EntityPig(new Vector2(position.X, position.Y)));
            }

            position.Y += velocity.Y;
            CheckCollision();
        }

        public override void Draw(SpriteBatch batch)
        {
            if (direction == 0)
                batch.Draw(level.resourceManager.images.GetImage("summoner"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
            if (direction == 1)
                batch.Draw(level.resourceManager.images.GetImage("summoner"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0.4f);
        }

    }
}
