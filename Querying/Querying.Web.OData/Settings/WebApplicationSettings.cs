﻿using System.Collections.Generic;
using System.Configuration;

using NuClear.AdvancedSearch.Common.Identities.Connections;
using NuClear.AdvancedSearch.Common.Settings;
using NuClear.CustomerIntelligence.Storage.Identitites.Connections;
using NuClear.Settings.API;
using NuClear.Storage.API.ConnectionStrings;

namespace NuClear.Querying.Web.OData.Settings
{
    public sealed class WebApplicationSettings : SettingsContainerBase
    {
        public WebApplicationSettings()
        {
            var connectionStringSettings = new ConnectionStringSettingsAspect(
                new Dictionary<IConnectionStringIdentity, string>
                {
                    {
                        CustomerIntelligenceConnectionStringIdentity.Instance,
                        ConfigurationManager.ConnectionStrings["CustomerIntelligence"].ConnectionString
                    },
                    {
                        LoggingConnectionStringIdentity.Instance,
                        ConfigurationManager.ConnectionStrings["Logging"].ConnectionString
                    }
                });

            Aspects.Use(connectionStringSettings)
                   .Use<EnvironmentSettingsAspect>();
        }
    }
}