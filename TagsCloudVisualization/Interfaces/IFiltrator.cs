using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IFiltrator
    {
        Result<WordsBox> Preprocessing(IEnumerable<string> input);
    }
}