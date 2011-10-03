using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Tasks
{
    public class RoleProviderTask<T,TUser>
        where T : RoleBase<TUser>
        where TUser : UserBase 
    {
    }
}
