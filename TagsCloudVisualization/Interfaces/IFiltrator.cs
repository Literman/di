using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IFiltrator
    {
        WordsBox Preprocessing(IEnumerable<string> input);
    }
}