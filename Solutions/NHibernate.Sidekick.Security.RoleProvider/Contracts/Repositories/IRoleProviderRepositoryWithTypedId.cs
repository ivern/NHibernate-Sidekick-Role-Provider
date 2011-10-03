using NHibernate.Sidekick.Security.RoleProvider.Domain;
using SharpArch.Domain.PersistenceSupport;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories
{
    public interface IRoleProviderRepositoryWithTypedId<T, TId> : ILinqRepository<T>
        where T: RoleBaseWithTypedId<TId>
    {
        T SaveOrUpdate(T role);
    }
}