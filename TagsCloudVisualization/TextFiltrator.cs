using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{
    public class TextFiltrator : IFiltrator
    {
        private readonly IFilter[] filters;
        private readonly int maxCount;

        public TextFiltrator(IFilter[] filters, Options options)
        {
            this.filters = filters;
            maxCount = options.Count;
        }

        public WordsBox Preprocessing(IEnumerable<string> input)
        {
            var filtered = filters.Aggregate(input, (current, filter) => filter.Filtrate(current));
            return Sort(filtered);
        }

        private WordsBox Sort(IEnumerable<string> wordlist)
        {
            return wordlist
                .GroupBy(word => word)
                .OrderByDescending(group => group.Count())
                .Take(maxCount)
                .ToWordsBox();
        }
    }
}