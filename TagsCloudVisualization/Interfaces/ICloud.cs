using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface ICloud
    {
        Result<None> Build(IEnumerable<string> input);
    }
}