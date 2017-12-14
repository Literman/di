using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IFilter
    {
        IEnumerable<string> Filtrate(IEnumerable<string> words);
    }
}