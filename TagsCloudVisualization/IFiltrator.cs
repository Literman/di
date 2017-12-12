using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IFiltrator
    {
        Dictionary<string, int> Preprocessing(IEnumerable<string> input);
    }
}