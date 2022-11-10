using Mod.ActivityPub.UI;

namespace Mod.ActivityPub.Example.Services
{
    public class ResourceLookup : IResourceLookup
    {
        public ResourceDescriptor LookupResource(string resource)
        {
            var r = new ResourceDescriptor();
            r.Subject = "acct:sirtwist@mod.digital";

            return r;
        }
    }
}
