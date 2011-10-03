using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using SharpArch.Domain.PersistenceSupport;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories
{
    public interface IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> : ILinqRepository<T>
        where T: RoleBaseWithTypedId<TId, TUser, TUserId>
        where TUser: UserBaseWithTypedId<TUserId>
    {
        T SaveOrUpdate(T role);
    }
}