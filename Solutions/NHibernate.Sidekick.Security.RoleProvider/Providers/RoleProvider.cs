using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Providers
{
    public abstract class RoleProvider<T, TUser> : RoleProviderWithTypedId<T, int, TUser, int>
        where T : RoleBase<TUser>, new()
        where TUser: UserBase 
    {
    }
}

