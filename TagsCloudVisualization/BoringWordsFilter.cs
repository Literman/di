using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{
    public class BoringWordsFilter : IFilter
    {
        private readonly int minLength;
        private readonly HashSet<string> boringWords = new HashSet<string>();

        public BoringWordsFilter(Options options)
        {
            minLength = options.Length;
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

        public IEnumerable<string> Filtrate(IEnumerable<string> words) => words.Where(NotBoringWords);

        private bool NotBoringWords(string word) => !boringWords.Contains(word) && word.Length > minLength;
    }
}