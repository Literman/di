using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IFilter
    {
        void AddBoringWords(params string[] words);

        void RemoveBoringWords(params string[] words);

        Dictionary<string, int> Preprocessing(IEnumerable<string> list);
    }
}