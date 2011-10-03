using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks
{
    public interface IRoleProviderTask<T,TUser> : IRoleProviderTaskWithTypedId<T,int,TUser,int>
        where T : RoleBaseWithTypedId<int,TUser,int>
        where TUser: UserBase
    {
    }
}