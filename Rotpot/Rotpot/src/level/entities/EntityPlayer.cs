﻿using Microsoft.Xna.Framework;
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
        private Vector2 spawn;

        private Animation runningAnim, jumpingAnim;
        private bool jumping;

        public int direction = 0;
        public bool moving = false;

        private int dashCooldown = 10;
        private int dashDirection = 0;
        private float dashAlpha = 0;
        private Vector2 dashPosition;
        private Rectangle dashRectangle;

        public EntityPlayer(Vector2 position)
        {
            this.position = position;
            this.spawn = position;
            health = 240;
            movementSpeed = 10;

            width = 192;
            height = 192;
            runningAnim = new Animation(5, 0, 0, width, height, 12 * width, height, true);
            jumpingAnim = new Animation(5, 0, 1, width, height, 9 * width, height * 2, false);
            width = 150;
            strength = 100;
        }

        public void Respawn()
        {
            health = 240;
            strength = 0;
            velocity = new Vector2(0, 0);
            position = spawn;
        }

        public override void Update(GameTime gameTime)
        {
            Main.camera.Position += ((position - new Vector2(1920 / 2 - width / 2, 1080 / 2 - height / 2)) - Main.camera.Position) / 5;

            level.entityManager.AddEntity(level, new ParticleStar(new Vector2(position.X + width / 2, position.Y + rdn.Next(height + 10))));
            level.entityManager.AddEntity(level, new ParticleBackgroundBig(new Vector2(position.X + rdn.Next(width - 1000, width + 1000), position.Y + rdn.Next(height - 1000, height + 1000))));

            if (!OnGround())
            {
                velocity.Y += GRAVITY;
                jumpingAnim.Update();

                if (InputHandler.attack)
                {
                    if (strength >= 100)
                    {
                        velocity.Y = -23f;
                        strength = 0;
                        InputHandler.releaseJump = true;
                        InputHandler.attack = false;
                    }
                }
            }
            else
            {
                jumping = false;
                jumpingAnim.Reset();
                if (velocity.Y > 0) velocity.Y = 0f;
                if (InputHandler.attack)
                {
                    InputHandler.releaseJump = true;
                    InputHandler.attack = false;
                    velocity.Y = -23;
                    for(int i = 0; i < 5; i++)
                    {
                        level.entityManager.AddEntity(level, new ParticleDust(new Vector2(position.X + width / 2, position.Y + height + 40), new Vector2(0, -0.4f), 0.5f));
                    }
                    jumping = true;
                }
            }

            Vector2 movement = Vector2.Zero;
            if (InputHandler.left) movement += new Vector2(-movementSpeed, 0);
            if (InputHandler.right) movement += new Vector2(movementSpeed, 0);

            if(strength < 100) strength++;
            dashCooldown--;
            if (dashAlpha > 0) dashAlpha -= 0.02f;

            if (movement != Vector2.Zero)
            {
                moving = true;
                if (!jumping) level.entityManager.AddEntity(level, new ParticleDust(new Vector2(position.X + width / 2, position.Y + height), new Vector2(direction * 3, -1.5f), 0.3f));

                if (movement.X > 0) direction = 1;
                else direction = -1;
                if (velocity.Y == 0) runningAnim.Update();

                if (strength >= 50 && InputHandler.shift && dashCooldown <= 0)
                {
                    strength -= 10;
                    dashCooldown = 10;
                    strength -= 50;
                    dashRectangle = runningAnim.GetRectangle();
                    dashPosition = position;
                    dashAlpha = 1f;
                    dashDirection = direction;
                    InputHandler.shift = false;

                    for(int i = 0; i < 300; i += 10)
                    {
                        position += movement;
                        CheckCollision();
                    }
                    movement = Vector2.Zero;
                }
            }
            else
            {
                runningAnim.Reset();
                moving = false;
            }
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
            if(dashAlpha > 0)
            {
                batch.Draw(level.resourceManager.images.GetImage("player"), dashPosition, dashRectangle, new Color(1, 1, 1, dashAlpha), 0f, new Vector2(0, 0), 1, dashDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0.5f);
            } 
            if (direction == 1)
            {
                if(!jumping) batch.Draw(level.resourceManager.images.GetImage("player"), position, runningAnim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.5f);
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
