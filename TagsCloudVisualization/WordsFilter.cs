using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{
    public class WordsFilter : IFilter
    {
        private readonly int minLength;
        private readonly int maxCount;
        private readonly HashSet<string> boringWords = new HashSet<string>();

        public WordsFilter(Options options)
        {
            minLength = options.Length;
            maxCount = options.Count;
        }

        public void AddBoringWords(params string[] words)
        {
            foreach (var word in words)
                boringWords.Add(word);
        }

        public void RemoveBoringWords(params string[] words)
        {
            foreach (var word in words)
                boringWords.Remove(word);
        }

        private bool NotBoringWords(string word) => !boringWords.Contains(word) && word.Length > minLength;

        public Dictionary<string, int> Preprocessing(IEnumerable<string> wordlist)
        {
            return wordlist.Select(word => word.ToLower())
                .Where(NotBoringWords)
                .GroupBy(word => word)
                .OrderByDescending(group => group.Count())
                .Take(maxCount)
                .ToDictionary(word => word.Key, words=> words.Count());
        }
    }
}