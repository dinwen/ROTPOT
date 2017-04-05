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
        public Rectangle headRectangle;
        public bool isRetreat, isAttack;

        public EntityMygga(Vector2 position)
        {
            movementSpeed = 5;
            patrolSpeed = 3;


            health = 1;
            strength = 1;
            this.position = position;
            direction = 0;

            width = 128;
            height = 128;
            animation = new Animation(5, 0, 0, width, height, 4, 0, true);
        }



        //animation?
        public override void Draw(SpriteBatch batch)
        {
            Console.WriteLine("awdawda");
            if (direction == 0)
                batch.Draw(level.resourceManager.images.GetImage("mygga 128x128"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.5f);
            if (direction == 1)
                batch.Draw(level.resourceManager.images.GetImage("mygga 128x128"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0.5f);
        }

        public override void Update(GameTime gameTime)
        {

            isAttack = true;
            animation.Update();

            if (isAttack)
            {
                myggaAttack();
            }
            //Attacking/ dealing dmg / close
            if (GetDistance(level.GetPlayer().GetPosition()) < 50)
            {
                level.GetPlayer().Damage(10);
                movementSpeed = 0;
                myggaRetreat();
                isAttack = false;
            }
            if (GetDistance(level.GetPlayer().GetPosition()) > 2000)
            {
                isRetreat = false;
            }


            CheckCollision();

        }

        public void myggaRetreat()
        {


            if (level.GetPlayer().GetPosition().X < position.X)
            {
                direction = 0;
                position -= new Vector2(-movementSpeed + 2, 0);
            }

            if (level.GetPlayer().GetPosition().X > position.X)
            {
                direction = 1;
                position -= new Vector2(movementSpeed + 2, 0);

            }
        }

        public void myggaAttack()
        {
            if (level.GetPlayer().GetPosition().X < position.X)
            {
                direction = 0;
                position += new Vector2(-movementSpeed, 0);
            }

            if (level.GetPlayer().GetPosition().X > position.X)
            {
                direction = 1;
                position += new Vector2(movementSpeed, 0);
            }

            if(level.GetPlayer().GetPosition().Y < position.Y)
            {

                position += new Vector2(-movementSpeed, 0);

            }

            if (level.GetPlayer().GetPosition().Y > position.Y)
            {

                position -= new Vector2(-movementSpeed, 0);
            }
            


        }
    }
}
