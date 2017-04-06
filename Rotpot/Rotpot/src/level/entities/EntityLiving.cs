using Microsoft.Xna.Framework;
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

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public bool OnGround()
        {
            if (onSolidEntity)
            {
                onSolidEntity = false;
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

        public void CheckCollision()
        {
            foreach (Tile t in level.tiles)
            {
                if (GetBoundsTop().Intersects(t.GetBounds()))
                {
                    position.Y = t.position.Y + t.collision.Height;
                    velocity.Y = 1;
                }
                if (GetBoundsBottom().Intersects(t.GetBounds()))
                {
                    Console.WriteLine("Tiles");
                    position.Y = t.position.Y - height + t.offset.Y;
                }
                if (GetBoundsLeft().Intersects(t.GetBounds()))
                {
                    position.X = t.position.X + t.collision.Height;
                }
                if (GetBoundsRight().Intersects(t.GetBounds()))
                {
                    position.X = t.position.X - width + t.offset.X;
                }
            }
        }


        //Collision Boxes

        public Rectangle GetBoundsInGround()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height, width - (int)movementSpeed * 2, (int)movementSpeed * 2);
        }

        public Rectangle GetBoundsW()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height, width - (int)movementSpeed * 2, (int)movementSpeed * 2);
        }

        public Rectangle GetBoundsBottom()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y + height - (int)movementSpeed, width - (int)movementSpeed * 2, (int)movementSpeed);
        }

        public Rectangle GetBoundsTop()
        {
            return new Rectangle((int)position.X + (int)movementSpeed, (int)position.Y, width - (int)movementSpeed * 2, (int)movementSpeed);
        }

        public Rectangle GetBoundsRight()
        {
            return new Rectangle((int)position.X + width - (int)movementSpeed, (int)position.Y + (int)movementSpeed, (int)movementSpeed, height - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsLeft()
        {
            return new Rectangle((int)position.X, (int)position.Y + (int)movementSpeed, (int)movementSpeed, height - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsFull()
        {
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

    }
}
