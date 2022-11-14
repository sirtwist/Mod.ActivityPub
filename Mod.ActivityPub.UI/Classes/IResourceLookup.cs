using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.ActivityPub.UI
{
    public interface IResourceLookup
    {
        public ResourceDescriptor? GetResource(string resource);
        public NodeInfo GetNodeInfo();
    }
}
