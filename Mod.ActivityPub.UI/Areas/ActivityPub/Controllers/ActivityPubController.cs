// Copyright 2022 Mod Digital LLC. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;

namespace Mod.ActivityPub.UI.Areas.ActivityPub.Controllers
{
    [NonController]
    public class ActivityPubController : Controller
    {
        private readonly IResourceLookup _lookup;

        public ActivityPubController(IResourceLookup lookup)
        {            
            _lookup = lookup ?? throw new ArgumentNullException(nameof(lookup));
        }

        [Route(".well-known/webfinger")]
        public IActionResult Webfinger(string resource)
        {
            var res = _lookup.LookupResource(resource);
            var result = Json(res, new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
            result.ContentType = "application/jrd+json";
            return result;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
