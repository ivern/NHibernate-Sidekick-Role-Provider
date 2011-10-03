using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories
{
    public interface IRoleProviderRepository<T,TUser> : IRoleProviderRepositoryWithTypedId<T,int,TUser,int>
        where T : RoleBase<TUser>
        where TUser : UserBase 
    {}
}
