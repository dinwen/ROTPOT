using Microsoft.Xna.Framework;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Rotpot.src.level.entities
{
    class EntityBox : EntityLiving
    {

        public EntityBox(Vector2 position)
        {
            this.position = position;
            this.width = 434;
            this.height = 372;
            this.movementSpeed = 5;
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

            EntityPlayer player = level.GetPlayer();
            if (GetBoundsLeft().Intersects(player.GetBoundsFull()))
            {
                position.X = player.GetPosition().X + player.width;
                player.movementSpeed = 1f;
            }
            if (GetBoundsRight().Intersects(player.GetBoundsFull()))
            {
                position.X = player.GetPosition().X - width;
                player.movementSpeed = 1f;
            }
            if(player.GetBoundsInGround().Intersects(GetBoundsFull()))
            {
                player.SetPosition(new Vector2(player.GetPosition().X, position.Y - player.height));
                player.SetVelocity(new Vector2(0, 0));
                player.onSolidEntity = true;
            }

            position += velocity;
            CheckCollision();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("box"), position, Color.White);
        }

    }
}
