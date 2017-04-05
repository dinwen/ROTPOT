using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpelProjekt.src.utils;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    public class EntityPlayer : EntityLiving
    {

        private Animation runningAnim, jumpingAnim;
        private bool jumping;
        private int direction = 0;
       
        public EntityPlayer()
        {
            health = 240;
            movementSpeed = 10;

            position = new Vector2(479 * 128, 12 * 128);

            width = 192;
            height = 192;
            runningAnim = new Animation(5, 0, 0, width, height, 12 * width, height, true);
            jumpingAnim = new Animation(5, 0, 1, width, height, 9 * width, height * 2, false);
            width = 150;
        }

        public void Respawn()
        {
            health = 240;
            strength = 0;
            velocity = new Vector2(0, 0);
            position = new Vector2(200, 400);
        }

        public override void Update(GameTime gameTime)
        {
            Main.camera.Position = position - new Vector2(1920 / 2 - width / 2, 1080 / 2 - height / 2);


            level.entityManager.AddEntity(level, new ParticleStar(new Vector2(position.X + width / 2, position.Y + rdn.Next(height + 10))));
           // level.entityManager.AddEntity(level, new ParticleBackground(new Vector2(position.X + rdn.Next(width - 1000, width + 1000), position.Y + rdn.Next(height - 1000, height + 1000))));
            level.entityManager.AddEntity(level, new ParticleBackgroundBig(new Vector2(position.X + rdn.Next(width - 1000, width + 1000), position.Y + rdn.Next(height - 1000, height + 1000))));
            //level.entityManager.AddEntity(level, new ParticleDust(position));

            if (!OnGround())
            {
                velocity.Y += GRAVITY;
                jumpingAnim.Update();

                if(InputHandler.attack)
                {

                }
            }
            else
            {
                jumping = false;
                jumpingAnim.Reset();
                if (velocity.Y > 0) velocity.Y = 0f;
                if (InputHandler.attack)
                {
                    velocity.Y = -23; //23
                    jumping = true;
                }
            }

            Vector2 movement = Vector2.Zero;
            if (InputHandler.left) movement += new Vector2(-movementSpeed, 0);
            if (InputHandler.right) movement += new Vector2(movementSpeed, 0);

            if (movement != Vector2.Zero)
            {
                if (movement.X > 0) direction = 1;
                else direction = -1;
                if(velocity.Y == 0) runningAnim.Update();
            }
            else runningAnim.Reset();
            position += movement;

            position += velocity;

            if (position.Y > 7000) health-= 3;

            CheckCollision();
            


            if (health <= 0)
            {
                this.Respawn();
            }

            movementSpeed = 10;
        }

        public override void Draw(SpriteBatch batch)
        {
            if (direction == 1)
            {
                if(!jumping)  batch.Draw(level.resourceManager.images.GetImage("player"), position, runningAnim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.5f);
                else batch.Draw(level.resourceManager.images.GetImage("player"), position, jumpingAnim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.5f);
            }
            else
            {
                if(!jumping) batch.Draw(level.resourceManager.images.GetImage("player"), position, runningAnim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0.5f);
                else batch.Draw(level.resourceManager.images.GetImage("player"), position, jumpingAnim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0.5f);
            }
        }

    }
}
