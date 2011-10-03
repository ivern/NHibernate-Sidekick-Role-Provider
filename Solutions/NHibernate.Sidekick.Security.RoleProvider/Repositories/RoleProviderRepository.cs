using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Repositories
{
    public class RoleProviderRepository<T, TUser> : RoleProviderRepositoryWithTypedId<T, int, TUser, int>
        where T : RoleBase<TUser>
        where TUser : UserBase 
    {}
}