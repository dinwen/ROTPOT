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
        private bool avoidGround;
        private int avoidGruondCooldown = 30;

        float pan;
        float movementSoundCooldown = 0;
        int randomAttack = rdn.Next(1, 3);

        private float rotation;
        private float retreatPos;
        private Vector2 respawn;

        public EntityMygga(Vector2 position, float retreatPos)
        {
            this.retreatPos = retreatPos;
            movementSpeed = 30;
            patrolSpeed = 3;

            health = 1;
            strength = 1;
            this.position = position;
            this.respawn = position;
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
            Remove();
        }

        public override void Update(GameTime gameTime)
        {

            pan = 1 / GetDistance(level.GetPlayer().GetPosition());

            CheckCollision();

            if (!isRetreat)
            {
                myggaAttack();
            }
            else myggaRetreat();


            //Attacking/ dealing dmg / close
            if (!isRetreat && GetDistance(level.GetPlayer().GetPosition()) < 50)
            {
                level.GetPlayer().Damage(10);
                movementSpeed = 15;
                isRetreat = true;
            }
            if (GetDistance(level.GetPlayer().GetPosition()) > 500)
            {
                isRetreat = false;
            }

            if (OnGround())
            {
                avoidGround = true;
            }
            if (level.GetPlayer().GetPosition().X > retreatPos) isRetreat = true;

            if (avoidGround)
            {

            }

            if (!avoidGround)
            {
                if (!isRetreat) myggaAttack();
                else myggaRetreat();
            }
            else
            {
                position += new Vector2(0, -6f);
                if(--avoidGruondCooldown <= 0)
                {
                    avoidGruondCooldown = 30;
                    avoidGround = false;
                }
            }

            PlaySound();
            rotation = GetDirection(level.GetPlayer().GetPosition()) - MathHelper.ToRadians(180);
        }

        public void myggaRetreat()
        {
            EntityPlayer player = level.GetPlayer();
            float dir = GetDirection(player.GetPosition());
            float xs = (float)Math.Cos(dir) * 10;
            float ys = (float)Math.Sin(dir) * 10;
            position += new Vector2(-xs, -ys);
            CheckCollision();
        }

        public void myggaAttack()
        {
            EntityPlayer player = level.GetPlayer();
            float dir = GetDirection(player.GetPosition());
            float xs = (float)Math.Cos(dir) * 6;
            float ys = (float)Math.Sin(dir) * 6;
            position += new Vector2(xs, ys);
            CheckCollision();
        }

        public void PlaySound()
        {
            if (GetDistance(level.GetPlayer().GetPosition()) < 1000)
            {
                if (--movementSoundCooldown <= 0)
                {
                    movementSoundCooldown = 30f;
                    level.resourceManager.audio.GetSound(0).Play(0.1f, 0.5f, 0);
                }
            }
            if (GetDistance(level.GetPlayer().GetPosition()) < 50)
            {
                level.resourceManager.audio.GetSound(rdn.Next(1, 3)).Play(1f, 1, 0);
            }
        }
    }
}
