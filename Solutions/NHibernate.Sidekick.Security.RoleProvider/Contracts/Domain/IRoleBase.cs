using NHibernate.Sidekick.Security.MembershipProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain
{
    public interface IRoleBase<TUser> : IRoleBaseWithTypedId<int,TUser,int>
        where TUser : UserBaseWithTypedId<int>
    {
    }
}