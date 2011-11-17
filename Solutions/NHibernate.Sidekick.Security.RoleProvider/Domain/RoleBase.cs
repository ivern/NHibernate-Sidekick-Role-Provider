using System;
using System.Diagnostics;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    [DebuggerDisplay("{RoleName}")]
    public abstract class RoleBase<TUser> : RoleBaseWithTypedId<int, TUser, int>
        where TUser : UserBase
    {}
}