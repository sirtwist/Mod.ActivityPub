// Copyright 2022 Mod Digital LLC. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Mod.ActivityPub.UI
{

    /// <summary>
    /// Extension method on <see cref="IMvcBuilder"/> to add UI
    /// for Microsoft.Identity.Web.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a controller and Razor pages for the accounts management.
        /// </summary>
        /// <param name="builder">MVC builder.</param>
        /// <returns>MVC builder for chaining.</returns>
        public static IMvcBuilder AddActivityPubUI(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ConfigureApplicationPartManager(apm =>
            {
                apm.FeatureProviders.Add(new ActivityPubControllerFeatureProvider());
            });

            return builder;
        }
    }
}
