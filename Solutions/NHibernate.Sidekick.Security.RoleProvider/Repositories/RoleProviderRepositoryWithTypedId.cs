using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using SharpArch.NHibernate;

namespace NHibernate.Sidekick.Security.RoleProvider.Repositories
{
    public class RoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> : LinqRepository<T>, IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> 
        where T : RoleBaseWithTypedId<TId,TUser,TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
    }
}
