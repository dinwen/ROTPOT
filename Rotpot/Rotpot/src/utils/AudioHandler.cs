using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan.utils
{
    public class AudioHandler
    {
        public Dictionary<int, SoundEffect> sounds = new Dictionary<int, SoundEffect>();

        public void AddAudio(int id, SoundEffect audio)
        {
            sounds.Add(id, audio);
        }

        public SoundEffect GetSound(int id)
        {
            return sounds[id];
        }
    }
}
