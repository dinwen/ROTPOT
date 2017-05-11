using Microsoft.Xna.Framework;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Rotpot.src.utils;

namespace Rotpot.src.level.entities
{
    class EntityBox : EntityLiving
    {
        private bool isMoving;
        private int cooldown;

        public EntityBox(Vector2 position)
        {
            cooldown = 120;
            isMoving = false;
            this.position = position;
            this.width = 434;
            this.height = 372;
            this.movementSpeed = 2;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!OnGround())
            {
                velocity.Y += GRAVITY;
            }
            else
            {
                velocity = new Vector2(0, 0);
            }

            isMoving = false;
            EntityPlayer player = level.GetPlayer();
            if (GetBoundsLeft().Intersects(player.GetBoundsFull()))
            {
                isMoving = true;
                position.X = player.GetPosition().X + player.width;
                player.movementSpeed = 1f;
            }
            if (GetBoundsRight().Intersects(player.GetBoundsFull()))
            {
                isMoving = true;
                position.X = player.GetPosition().X - width;
                player.movementSpeed = 1f;
            }
            if (player.GetBoundsInGround().Intersects(GetBoundsFull()))
            {
                player.SetPosition(new Vector2(player.GetPosition().X, position.Y - player.height));
                player.SetVelocity(new Vector2(0, 0));
                player.onSolidEntity = true;
            }

            position += velocity;
            CheckCollision();

            cooldown--;
            if(isMoving == true)
            {
                if(cooldown <= 0)
                {
                    level.entityManager.AddEntity(level, new EntityPig(new Vector2(position.X - 800, position.Y)));
                    cooldown = 120;
                }
            }


        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("box"), position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
        }

    }
}
