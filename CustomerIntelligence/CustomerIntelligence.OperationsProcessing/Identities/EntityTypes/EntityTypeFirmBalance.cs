﻿using NuClear.CustomerIntelligence.Domain;
using NuClear.Model.Common.Entities;

namespace NuClear.CustomerIntelligence.OperationsProcessing.Identities.EntityTypes
{
    public sealed class EntityTypeFirmBalance : EntityTypeBase<EntityTypeFirmBalance>
    {
        public override int Id
        {
            get { return EntityTypeIds.FirmBalance; }
        }

        public override string Description
        {
            get { return "FirmBalance"; }
        }
    }
}