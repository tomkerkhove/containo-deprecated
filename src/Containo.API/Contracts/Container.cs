using System.Collections.Generic;

namespace Containo.API.Contracts
{
    public class Container
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public IDictionary<string, string> Labels { get; set; }
        public IList<string> Names { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
    }
}