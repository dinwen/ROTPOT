using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan.utils
{
    public class LevelLoader
    {

        private string path;
        public List<Tile> loadedTiles = new List<Tile>();

        public LevelLoader(string path)
        {
            this.path = path;

            LoadTextFile();
        }

        private void LoadTextFile()
        {
            string fullText = "";
            if (File.Exists(path))
            {
                Console.WriteLine("Found File!");
                using (StreamReader reader = new StreamReader(File.OpenRead(path)))
                {
                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        fullText += line + "\n";
                    }
                }

                string[] lines = fullText.Split('\n');

                int width = 0;
                int height = 0;
                for (int i = 0; i < lines.Count()-2; i++)
                {

                    if (i == 0)
                    {
                        width = Convert.ToInt32(lines[i].Split('=')[1]);
                    }
                    else if (i == 1)
                    {
                        height = Convert.ToInt32(lines[i].Split('=')[1]);
                    }
                    else
                    {
                        string[] ids = lines[i].Split(',');
                        for (int x = 0; x < width; x++)
                        {
                            if (ids[x] != "")
                            {
                                int id = Convert.ToInt32(ids[x]);
                                if (id != 0)
                                {
                                    loadedTiles.Add(new Tile(x * 32, (i - 2) * 32, Tile.tiles[id]));
                                }
                            }
                        }
                    }
                }
            }
            
        }

    }
}
