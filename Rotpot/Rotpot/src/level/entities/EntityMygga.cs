using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpelProjekt.src.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class EntityMygga : EntityLiving
    {
        int direction;
        public float patrolSpeed;
        private Animation animation;
        public bool isRetreat;

        private float rotation;

        public EntityMygga(Vector2 position)
        {
            movementSpeed = 20;
            patrolSpeed = 3;


            health = 1;
            strength = 1;
            this.position = position;
            direction = 0;

            width = 128;
            height = 128;
            animation = new Animation(2, 0, 0, width, height, 5*width, height, true);
            width = 128/ 2;
            height = 128/2;
        }

        //animation?
        public override void Draw(SpriteBatch batch)
        {
            animation.Update();

            if (direction == 0)
                batch.Draw(level.resourceManager.images.GetImage("mygga 128x128"), position, animation.GetRectangle(), Color.White, rotation, new Vector2(64, 64), 1, SpriteEffects.FlipVertically, 0.5f);
            if (direction == 1)
                batch.Draw(level.resourceManager.images.GetImage("mygga 128x128"), position, animation.GetRectangle(), Color.White, rotation, new Vector2(64, 64), 1, SpriteEffects.FlipHorizontally, 0.5f);
        }

        public override void Reset()
        {
            position = new Vector2(-350, 43 * 128);
        }

        public override void Update(GameTime gameTime)
        {
            CheckCollision();

            if (!isRetreat) myggaAttack();
            else myggaRetreat();

            if (level.GetPlayer().GetPosition().X > 20000) Remove();

            //Attacking/ dealing dmg / close
            if (!isRetreat && GetDistance(level.GetPlayer().GetPosition()) < 50)
            {
                level.GetPlayer().Damage(10);
                movementSpeed = 0;
                isRetreat = true;
            }
            if (GetDistance(level.GetPlayer().GetPosition()) > 500)
            {
                isRetreat = false;
            }

            if (OnGround())
            {
                isRetreat = true;
            }

            rotation = GetDirection(level.GetPlayer().GetPosition()) - MathHelper.ToRadians(180);
        }

        public void myggaRetreat()
        {
            EntityPlayer player = level.GetPlayer();
            float dir = GetDirection(player.GetPosition());
            float xs = (float)Math.Cos(dir) * 15;
            float ys = (float)Math.Sin(dir) * 15;
            position += new Vector2(-xs, -ys);
        }

        public void myggaAttack()
        {
            EntityPlayer player = level.GetPlayer();
            float dir = GetDirection(player.GetPosition());
            float xs = (float)Math.Cos(dir) * 10;
            float ys = (float)Math.Sin(dir) * 10;
            position += new Vector2(xs, ys);
        }
    }
}
