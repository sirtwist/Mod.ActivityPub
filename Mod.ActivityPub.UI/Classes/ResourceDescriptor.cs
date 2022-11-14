using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.ActivityPub.UI
{
    public class ResourceDescriptor
    {
        public string? Subject { get; set; }
        public DateTime? Expires { get; set; }
        public IEnumerable<string>? Aliases { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
        public IEnumerable<ResourceDescriptorLink>? Links { get; set; }
    }

    public class ResourceDescriptorLink
    {
        public string Rel { get; set; }
        public string? Href { get; set; }
        public string? Type { get; set; }
        public Dictionary<string, string>? Titles { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
    }
}
