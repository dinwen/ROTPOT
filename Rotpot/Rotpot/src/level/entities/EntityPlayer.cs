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

        private Animation animation;
       
        public EntityPlayer()
        {
            health = 240;
            movementSpeed = 10;

            position = new Vector2(200, 400);

            width = 192;
            height = 192;
            animation = new Animation(5, 0, 0, width, height, 12 * width, height, true);

        }

        public void Respawn()
        {
            health = 240;
            strength = 0;
            position = new Vector2(200, 400);
        }

        public override void Update(GameTime gameTime)
        {
            Main.camera.Position = position - new Vector2(1920 / 4 - width / 2, 1080 / 4 - height / 2);

            if (!OnGround()) velocity.Y += GRAVITY;
            else
            {
                if (velocity.Y > 0) velocity.Y = 0f;
                if (InputHandler.attack) velocity.Y = -23;
            }

            if (InputHandler.left) position += new Vector2(-movementSpeed, 0);
            if (InputHandler.right) position += new Vector2(movementSpeed, 0);


            position += velocity;

            animation.Update();

            if (position.Y > 7000) health-= 3;

            CheckCollision();
            


            if (health <= 0)
            {
                this.Respawn();
            }

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("player"), position, animation.GetRectangle(), Color.White);
        }

    }
}
