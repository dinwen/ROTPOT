using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rotpot.src.utils
{
    class ParticleHandler
    {
        private Dictionary<string, Texture2D> particles = new Dictionary<string, Texture2D>();

        public void AddParticle(string name, Texture2D particle)
        {
            particles.Add(name, particle);
        }

        public Texture2D GetParticle(string name)
        {
            return particles[name];
        }
        //hejhej
    }
}
