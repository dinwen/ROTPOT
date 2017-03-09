﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.utils
{
    public class EntityManager
    {

        private Level level;

        public EntityManager(Level level)
        {
            this.level = level;
        }

        public void AddEntity(Level level, Entity entity, int id)
        {
            entity.Init(level);
            entity.id = id;
            if (Entity.firstEntity == null)
            {
                Entity.firstEntity = entity;
                return;
            }

            Entity step = Entity.firstEntity;

            while (step.nextEntity != null)
            {
                step = step.nextEntity;
            }

            step.nextEntity = entity;
        }

        public Entity GetEntity(int id)
        {
            Entity step = Entity.firstEntity;

            while (step.id != id)
            {
                if (step.nextEntity == null)
                {
                    step = null;
                    break;
                }
                step = step.nextEntity;
            }

            return step;
        }

        public void RemoveEntity(Entity entity)
        {
            Entity tmpEntityToRemove = entity;
            Entity step = Entity.firstEntity;
            bool removed = false;

            if (tmpEntityToRemove == null)
            {
                removed = true;
            }

            if (step == tmpEntityToRemove)
            {
                Entity.firstEntity = step.nextEntity;
                removed = true;
            }

            if (!removed)
            {
                while (step.nextEntity != tmpEntityToRemove)
                {
                    step = step.nextEntity;
                }
                step.nextEntity = step.nextEntity.nextEntity;
            }
        }

        public void Update()
        {
            Entity tmpEntity = Entity.firstEntity;
            while (tmpEntity != null)
            {
                tmpEntity.Update();
                if (tmpEntity.IsRemoved()) RemoveEntity(tmpEntity);
                tmpEntity = tmpEntity.nextEntity;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            Entity tmpEntity = Entity.firstEntity;
            while (tmpEntity != null)
            {
                tmpEntity.Draw(batch);
                tmpEntity = tmpEntity.nextEntity;
            }
        }

    }
}