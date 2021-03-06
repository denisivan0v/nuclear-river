﻿using System;

using NuClear.CustomerIntelligence.Domain;
using NuClear.Model.Common.Entities;

namespace NuClear.CustomerIntelligence.OperationsProcessing.Identities.EntityTypes
{
    [Obsolete("Сущность не имеет отношения к домену поиска, удалить после рефакторинга на стороне ERM")]
    public sealed class EntityTypeDeal : EntityTypeBase<EntityTypeDeal>
    {
        public override int Id
        {
            get { return EntityTypeIds.Deal; }
        }

        public override string Description
        {
            get { return "Deal"; }
        }
    }
}