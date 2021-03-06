﻿using NuClear.Model.Common.Operations.Identity;

namespace NuClear.CustomerIntelligence.OperationsProcessing.Identities.Operations
{
    public sealed class ImportCategoryOrganizationUnitIdentity : OperationIdentityBase<ImportCategoryOrganizationUnitIdentity>, INonCoupledOperationIdentity
    {
        public override int Id
        {
            get { return OperationIdentityIds.ImportCategoryOrganizationUnitIdentity; }
        }

        public override string Description
        {
            get { return "Импорт привязок рубрик к отделениям организации"; }
        }
    }
}