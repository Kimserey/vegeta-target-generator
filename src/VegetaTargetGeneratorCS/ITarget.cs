using System.Collections.Generic;

namespace VegetaTargetGeneratorCS
{
    public interface ITarget
    {
        string Name { get; }
        string Url { get; }
        string Method { get; }
        Dictionary<string, IEnumerable<string>> Header { get; }
        object MakeBody();
    }
}
