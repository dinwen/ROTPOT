﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    public class EntityLiving : Entity
    {
        public int width, height;
        protected float health;
        protected float strength;
        public float movementSpeed;

        public bool onSolidEntity = false;

        protected Vector2 velocity;
        protected const float GRAVITY = 0.82f;

        public EntityLiving()
        {

        }

        public void Move(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Damage(float damage)
        {
            health -= damage;
        }

        public float GetHealth()
        {
            return health;
        }

        public float GetStrength()
        {
            return strength;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch batch)
        {

        }

        public void SetVelocity(Vector2 vel)
        {
            this.velocity = vel;
        } 

        public bool OnGround()
        {
            if (onSolidEntity)
            {
                onSolidEntity = false;
                position.Y -= movementSpeed;
                return true;
            }
            foreach (Tile t in level.tiles)
            {
                if (t.GetBounds().Intersects(GetBoundsInGround()))
                {
                    if (velocity.Y > 0)
                    {
                        position.Y = t.position.Y - height;
                        velocity.Y = 0;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool CheckCollision()
        { 
            Entity stepper = Entity.firstEntity;
            if (this != stepper && GetDistance(stepper.GetPosition()) < 40)
            {
                float direction = GetDirection(stepper.GetPosition());
                stepper.SetPosition(stepper.GetPosition() + new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)));
            }
            while (stepper.nextEntity != null)
            {
                stepper = stepper.nextEntity;
                if (stepper is EntityLiving && this != stepper && GetDistance(stepper.GetPosition()) < 40)
                {
                    float direction = GetDirection(stepper.GetPosition());
                    stepper.SetPosition(stepper.GetPosition() + new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)));
                }
            }

            foreach (Tile t in level.tiles)
            {
                if (GetDistance(t.position) < 400)
                {
                    if (GetBoundsTop().Intersects(t.GetBounds()))
                    {
                        position.Y = t.position.Y + t.collision.Height;
                        velocity.Y = 1;
                        return true;
                    }
                    if (GetBoundsBottom().Intersects(t.GetBounds()))
                    {
                        position.Y = t.position.Y - height + t.offset.Y;
                        return true;
                    }
                    if (GetBoundsLeft().Intersects(t.GetBounds()))
                    {
                        position.X = t.position.X + t.collision.Height;
                        return true;
                    }
                    if (GetBoundsRight().Intersects(t.GetBounds()))
                    {
                        position.X = t.position.X - width + t.offset.X;
                        return true;
                    }
                }
            }
            return false;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        //Collision Boxes

        public Rectangle GetBoundsInGround()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height, width - (int)movementSpeed * 3, (int)movementSpeed * 3);
        }

        public Rectangle GetBoundsW()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height, width - (int)movementSpeed * 3, (int)movementSpeed * 3);
        }

        public Rectangle GetBoundsBottom()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height - (int)movementSpeed, width - (int)movementSpeed * 3, (int)movementSpeed);
        }

        public Rectangle GetBoundsTop()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y, width - (int)movementSpeed * 3, (int)movementSpeed);
        }

        public Rectangle GetBoundsRight()
        {
            return new Rectangle((int)position.X + width - (int)movementSpeed, (int)position.Y + (int)movementSpeed, (int)movementSpeed, height - 3 * (int)movementSpeed);
        }

        public Rectangle GetBoundsLeft()
        {
            return new Rectangle((int)position.X, (int)position.Y + (int)movementSpeed, (int)movementSpeed, height - 3 * (int)movementSpeed);
        }

        public Rectangle GetBoundsFull()
        {
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

    }
}
