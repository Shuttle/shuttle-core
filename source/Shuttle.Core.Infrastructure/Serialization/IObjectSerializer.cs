using System.Collections.Generic;
using System.Text;

namespace Shuttle.Core.Infrastructure
{
    public interface IObjectSerializer
    {
        string Serialize(object o);
        string Serialize(object o, IEnumerable<KeyValuePair<string, string>> namespaces);
        T Deserialize<T>(string xml) where T : class;
        T Deserialize<T>(string xml, Encoding encoding) where T : class;
    }
}
