using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC250
{
    public static class Isomorphs
    {
        public static string GetLooseValue(string word)
        {
            char[] chars = word.ToCharArray();
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (var letter in chars)
            {
                if (!frequencies.ContainsKey(letter)) frequencies[letter] = 1;
                else frequencies[letter]++;
            }
            var arraything = frequencies.Values.ToArray();
            arraything = Sorts.InsertionSort(arraything);
            string result = "";
            foreach (var item in arraything)
            {
                result += item.ToString();
            }
            return result;
        }

        public static string GetExactValue(string word)
        {
            char[] chars = word.ToCharArray();
            int nextid = 0;
            Dictionary<char, int> ids = new Dictionary<char, int>();
            foreach (var item in chars)
            {
                if (!ids.ContainsKey(item))
                {
                    ids[item] = nextid++;
                }
            }
            string result = "";
            foreach (var item in chars)
            {
                result += ids[item];
            }
            return result;
        }

        public static void DoIsomorphThings(IEnumerable<string> words)
        {
            Dictionary<string, List<string>> looseIsos = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> exactIsos = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                var looseValue = Isomorphs.GetLooseValue(word);
                var exactValue = Isomorphs.GetExactValue(word);
                if (!looseIsos.ContainsKey(looseValue)) looseIsos.Add(looseValue, new List<string>());
                looseIsos[looseValue].Add(word);
                if (!exactIsos.ContainsKey(exactValue)) exactIsos.Add(exactValue, new List<string>());
                exactIsos[exactValue].Add(word);
            }
            List<string> nonIsos = new List<string>();
            var loosekeys = looseIsos.Keys.ToArray();
            foreach (var item in loosekeys)
            {
                if (looseIsos[item].Count == 1)
                {
                    nonIsos.Add(looseIsos[item][0]);
                    looseIsos.Remove(item);
                }
            }
            loosekeys = looseIsos.Keys.ToArray();
            Array.Sort(loosekeys);
            var exactkeys = exactIsos.Keys.ToArray();
            Console.WriteLine("LOOSE ISOMORPHS:");
            foreach (var item in loosekeys)
            {
                Console.Write(item + "- ");
                foreach (var word in looseIsos[item])
                {
                    Console.Write(word);
                    if (looseIsos[item].IndexOf(word) != looseIsos[item].Count - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("EXACT ISOMORPHS:");
            Array.Sort(exactkeys);
            foreach (var item in exactkeys)
            {
                if (exactIsos[item].Count > 1)
                {
                    Console.Write(item + "- ");
                    foreach (var word in exactIsos[item])
                    {
                        Console.Write(word);
                        if (exactIsos[item].IndexOf(word) != exactIsos[item].Count - 1) Console.Write(", ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("NON ISOMORPHS:");
            for (int i = 0; i < nonIsos.Count; i++)
            {
                Console.Write(nonIsos[i]);
                if (i != nonIsos.Count - 1) Console.Write(", ");
            }
        }

        public static List<string> GetWordsFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            Array.Sort(lines);
            var list = lines.ToList();
            return list;
        }

        public static void IsomorphAnalyzeToFile(string path, IEnumerable<string> words)
        {
            if(File.Exists(path)) { File.Delete(path); }
            StreamWriter stream = new StreamWriter(path);
            Dictionary<string, List<string>> looseIsos = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> exactIsos = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                var looseValue = Isomorphs.GetLooseValue(word);
                var exactValue = Isomorphs.GetExactValue(word);
                if (!looseIsos.ContainsKey(looseValue)) looseIsos.Add(looseValue, new List<string>());
                looseIsos[looseValue].Add(word);
                if (!exactIsos.ContainsKey(exactValue)) exactIsos.Add(exactValue, new List<string>());
                exactIsos[exactValue].Add(word);
            }
            List<string> nonIsos = new List<string>();
            var loosekeys = looseIsos.Keys.ToArray();
            
            foreach (var item in loosekeys)
            {
                if (looseIsos[item].Count == 1)
                {
                    nonIsos.Add(looseIsos[item][0]);
                    looseIsos.Remove(item);
                }
            }
            loosekeys = looseIsos.Keys.ToArray();
            var exactkeys = exactIsos.Keys.ToArray();
            stream.WriteLine("LOOSE ISOMORPHS:");
            Array.Sort(loosekeys);
            foreach (var item in loosekeys)
            {
                stream.Write(item + "- ");
                foreach (var word in looseIsos[item])
                {
                    stream.Write(word);
                    if (looseIsos[item].IndexOf(word) != looseIsos[item].Count - 1) stream.Write(", ");
                }
                stream.WriteLine();
            }
            stream.WriteLine();
            stream.WriteLine("EXACT ISOMORPHS:");
            Array.Sort(exactkeys);
            foreach (var item in exactkeys)
            {
                if (exactIsos[item].Count > 1)
                {
                    stream.Write(item + "- ");
                    foreach (var word in exactIsos[item])
                    {
                        stream.Write(word);
                        if (exactIsos[item].IndexOf(word) != exactIsos[item].Count - 1) stream.Write(", ");
                    }
                    stream.WriteLine();
                }
            }
            stream.WriteLine();
            stream.WriteLine("NON ISOMORPHS:");
            for (int i = 0; i < nonIsos.Count; i++)
            {
                stream.Write(nonIsos[i]);
                if (i != nonIsos.Count - 1) stream.Write(", ");
            }

            stream.Close();
        }
    }
}
