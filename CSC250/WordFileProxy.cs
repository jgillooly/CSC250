using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250
{
    internal class WordFileProxy
    {
        private static WordFileProxy? instance = null;
        private Dictionary<string, List<string>>? wordCache;
        private Dictionary<string, DateTime>? lastUpdated;
        private WordFileProxy()
        {
        }

        public static WordFileProxy getInstance()
        {
            if (instance == null)
            {
                instance = new WordFileProxy();
                instance.wordCache = new Dictionary<string, List<string>>();
                instance.lastUpdated = new Dictionary<string, DateTime>();
            }
            return instance;
        }

        private List<string> GetWordsFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            Array.Sort(lines);
            var list = lines.ToList();
            return list;
        }

        public List<string> GetWordsByPath(string path)
        {
            if (wordCache[path] != null && File.GetLastWriteTime(path) == lastUpdated[path])
            {
                return wordCache[path];
            }
            else
            {
                var words = GetWordsFromFile(path);
                wordCache[path] = words;
                lastUpdated[path] = File.GetLastWriteTime(path);
                return words;
            }
        }
    }
}
