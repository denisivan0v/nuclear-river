using System.Linq;

using NuClear.AdvancedSearch.Replication.CustomerIntelligence.Model;

namespace NuClear.AdvancedSearch.Replication.CustomerIntelligence.Data.Context
{
    public interface ICustomerIntelligenceContext
    {
        IQueryable<CategoryGroup> CategoryGroups { get; }

        IQueryable<Client> Clients { get; }

        IQueryable<ClientContact> ClientContacts { get; }

        IQueryable<Firm> Firms { get; }

        IQueryable<FirmActivity> FirmActivities { get; }

        IQueryable<FirmBalance> FirmBalances { get; }

        IQueryable<FirmCategory> FirmCategories { get; }

        IQueryable<Project> Projects { get; }

        IQueryable<ProjectCategory> ProjectCategories { get; }

        IQueryable<Territory> Territories { get; }
    }
}