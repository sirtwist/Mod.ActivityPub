// Copyright 2022 Mod Digital LLC. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mod.ActivityPub.UI.Areas.ActivityPub.Controllers
{
    [NonController]
    public class ActivityPubController : Controller
    {
        private readonly IResourceLookup _lookup;
        private readonly IHttpContextAccessor _context;

        public ActivityPubController(IResourceLookup lookup, IHttpContextAccessor context)
        {            
            _lookup = lookup ?? throw new ArgumentNullException(nameof(lookup));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [Route(".well-known/webfinger")]
        public IActionResult Webfinger(string resource)
        {
            var res = _lookup.GetResource(resource);
            if (res == null)
            {
                return NotFound();
            }
            var result = Json(res, new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase });
            result.ContentType = "application/jrd+json";
            return result;
        }

        [Route(".well-known/nodeinfo")]
        public IActionResult NodeInfo()
        {

            var res = new ResourceDescriptor();
            res.Links = new List<ResourceDescriptorLink>
            {
                new ResourceDescriptorLink()
                {
                    Rel = "http://nodeinfo.diaspora.software/ns/schema/2.1",
                    Href = _context?.HttpContext?.Request.Scheme + "://" + _context?.HttpContext?.Request.Host + "/nodeinfo/2.1"
                }
            };

            var result = Json(res, new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase });
            result.ContentType = "application/jrd+json";
            return result;
        }

        [Route("nodeinfo/{version}")]
        public IActionResult NodeInfoDetail(string? version)
        {
            version = version ?? "2.1";
            var ni = _lookup.GetNodeInfo();
            
            JsonResult result;

            switch (version)
            {
                case "2.0":
                    ni.Software.Repository = null;
                    ni.Software.Homepage = null;
                    result = Json((object)ni, new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase });
                    result.ContentType = "application/jrd+json";
                    break;
                case "2.1":
                default:
                    result = Json((object)ni, new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase });
                    result.ContentType = "application/jrd+json";
                    break;

            }
            return result;
        }

    }
}
