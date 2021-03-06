﻿using NuClear.Model.Common;
using NuClear.Storage.API.ConnectionStrings;

namespace NuClear.AdvancedSearch.Common.Identities.Connections
{
    public class InfrastructureConnectionStringIdentity : IdentityBase<InfrastructureConnectionStringIdentity>, IConnectionStringIdentity
    {
        public override int Id
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "Infrastructure DB connections string identity"; }
        }
    }
}