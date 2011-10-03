using System;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    public abstract class RoleBase<TUser> : RoleBaseWithTypedId<int, TUser, int>
        where TUser : UserBase
    {}
}