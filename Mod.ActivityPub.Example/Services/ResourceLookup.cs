using Mod.ActivityPub.UI;

namespace Mod.ActivityPub.Example.Services
{
    public class ResourceLookup : IResourceLookup
    {
        IHttpContextAccessor _context;
        public ResourceLookup(IHttpContextAccessor context)
        {
            _context = context;
        }

        public NodeInfo GetNodeInfo()
        {
            var ni = new NodeInfo();
            ni.Software.Name = "ActivityPub Example";
            ni.Software.Homepage = "https://github.com/sirtwist/Mod.ActivityPub";
            ni.Software.Version = "1.0";
            ni.Software.Repository = "https://github.com/sirtwist/Mod.ActivityPub";
            ni.OpenRegistrations = false;
            ni.Services.Inbound = NodeServicesInbound.atom1_0 | NodeServicesInbound.rss2_0;
            ni.Services.Outbound = NodeServicesOutbound.atom1_0 | NodeServicesOutbound.rss2_0;
            ni.Protocols = NodeProtocols.activitypub;
            ni.Usage.Users.Total = 1;
            ni.Usage.Users.ActiveHalfyear = 1;
            ni.Usage.Users.ActiveMonth = 1;
            ni.Usage.LocalPosts = 0;
            ni.Usage.LocalComments = 0;
            ni.Metadata = new Dictionary<string, string>() {
                {"author", "George A. Roberts IV"
            }};
            return ni;
        }

        public ResourceDescriptor? GetResource(string resource)
        {
            var r = new ResourceDescriptor();
            if (resource.ToLowerInvariant() == "acct:sirtwist@mod.digital")
            {
                r.Subject = "acct:sirtwist@mod.digital";
                return r;
            }
            else
            {
                return null;
            }

        }

    }

}
