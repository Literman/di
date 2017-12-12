using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{
    public class LowerCaseFilter : IFilter
    {
        public IEnumerable<string> Filtrate(IEnumerable<string> words) => words.Select(word => word.ToLower());
    }
}