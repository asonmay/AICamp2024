using System.Diagnostics.Tracing;

namespace MarkovChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"\\GMRDC1\Folder Redirection\mason.lee\Documents\text.txt").ToLower();

            string[] words = text.Split([' ', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

            string[] sentence = GetSentence(words, "the");
            
            for(int i = 0; i < sentence.Length; i++)
            {
                Console.Write(sentence[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        
        static Dictionary<string, List<string>> GetWords(string[] words)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!dictionary.ContainsKey(words[i]))
                {
                    dictionary.Add(words[i], new List<string> { words[i + 1] });
                }
                else
                {
                    dictionary[words[i]].Add(words[i + 1]);
                }
            }
            return dictionary;
        }

        static string[] GetSentence(string[] words, string startingWord)
        {
            Dictionary<string, List<string>> dictionary = GetWords(words);
            List<string> sentance = new List<string>();
            Random random = new Random();
            sentance.Add(startingWord);

            while (sentance[^1][^1] != '.')
            {
                sentance.Add(dictionary[sentance[^1]][random.Next(dictionary[sentance[^1]].Count)]);
            }

            return sentance.ToArray();
        }
    }
}
