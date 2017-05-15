using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
    public class EntityPig : EntityLiving
    {

        public float patrolSpeed;
        private Animation animation;
        public Rectangle agroRange;

        int movementSoundCooldown = 0;
        int dmgSoundCooldown = 0;

        int dmgcooldown = 0;

        private int direction = 0;

        public EntityPig(Vector2 position)
        {
            movementSpeed = 5;
            patrolSpeed = 3;
            health = 1;
            strength = 1;

            this.position = position;

            width = 128;
            height = 128;

            animation = new Animation(5, 0, 0, width, height, 11 * width, height, true);
        }

        public override void Draw(SpriteBatch batch)
        {
            if (direction == 0)
                batch.Draw(level.resourceManager.images.GetImage("gris"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
            if (direction == 1)
                batch.Draw(level.resourceManager.images.GetImage("gris"), position, animation.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0.4f);
        }

        public override void Update(GameTime gameTime)
        {
            //level.resourceManager.audio.GetSound(4).Play();

            if (!OnGround())
            {
                velocity.Y += GRAVITY;
            }
            else
            {
                velocity = new Vector2(0, 0);
            }

            if (GetDistance(level.GetPlayer().GetPosition()) < 1000)
            {
                pigAlert();
                animation.Update();
            }
            
            else
            {
                position += new Vector2(-patrolSpeed, 0);
            }

            if (GetDistance(level.GetPlayer().GetPosition()) < 120)
            {
                if (--dmgcooldown <= 0)
                {
                    dmgcooldown = 40;
                    level.GetPlayer().Damage(20);
                }
            }

            if(level.GetPlayer().GetBoundsInGround().Intersects(this.GetBoundsFull()) && level.GetPlayer().GetVelocity().Y > 0)
            {
                level.GetPlayer().SetVelocity(new Vector2(level.GetPlayer().GetVelocity().X, -10));
                Remove();
                level.resourceManager.audio.GetSound(6).Play(1f, 0, 0);
            }

            PlaySound();
            position += velocity;
            CheckCollision();
        }

        public void pigAlert()
        {
            if (level.GetPlayer().GetPosition().X < position.X)
            {
                position += new Vector2(-movementSpeed, 0);
                direction = 1;
            }

            if (level.GetPlayer().GetPosition().X > position.X)
            {
                position += new Vector2(movementSpeed, 0);
                direction = +0;
            }
        }
        public void PlaySound()
        {
            if (GetDistance(level.GetPlayer().GetPosition()) < 1000)
            {
                if (--movementSoundCooldown <= 0)
                {
                    movementSoundCooldown = 33;
                    level.resourceManager.audio.GetSound(4).Play(1f, 0, 0);
                }
            }
            if (GetDistance(level.GetPlayer().GetPosition()) < 120)
            {
                if (--dmgSoundCooldown <= 0)
                {
                    dmgSoundCooldown = 40;
                    level.resourceManager.audio.GetSound(5).Play();
                }
            }
        }
    }
}
