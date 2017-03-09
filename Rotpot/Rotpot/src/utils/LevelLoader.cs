using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    class LevelLoader
    {

        private List<Tile> loadedTiles = new List<Tile>();
        private ResourceManager resources;
        private Vector2 size = Vector2.Zero;

        public LevelLoader(ResourceManager resources, string path)
        {
            this.resources = resources;
            Load(path);
        }

        private void Load(string path)
        {
            string fullText = "";

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(path)))
                {
                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        fullText += line + "\n";
                    }
                }

                string[] lines = fullText.Split('\n');

                for (int y = 0; y < lines.Length - 1; y++)
                {
                    string[] ids = lines[y].Split(',');
                    for (int x = 0; x < ids.Length; x++)
                    {
                        int id = Convert.ToInt32(ids[x]);
                        if (id != -1)
                        {
                            loadedTiles.Add(new Tile(new Vector2(x * 32, y * 32), resources.tiles.GetTile(id)));
                        }
                    }
                }
            }
        }

        public List<Tile> GetLevelTiles()
        {
            return loadedTiles;
        }

    }
}
