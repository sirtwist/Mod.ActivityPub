// Copyright 2022 Mod Digital LLC. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Mod.ActivityPub.UI.Areas.ActivityPub.Controllers;

namespace Mod.ActivityPub.UI
{
    internal class ActivityPubControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            if (!feature.Controllers.Contains(typeof(ActivityPubController).GetTypeInfo()))
            {
                feature.Controllers.Add(typeof(ActivityPubController).GetTypeInfo());
            }
        }
    }

}
