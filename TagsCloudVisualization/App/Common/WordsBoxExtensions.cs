using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{
    public static class WordsBoxExtensions
    {
        public static WordsBox ToWordsBox(this IEnumerable<IGrouping<string, string>> groups) =>
            new WordsBox(groups.ToDictionary(word => word.Key, words => words.Count()));
    }
}