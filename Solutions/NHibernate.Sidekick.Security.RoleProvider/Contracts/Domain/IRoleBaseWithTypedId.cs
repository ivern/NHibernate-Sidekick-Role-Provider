using System.Collections.Generic;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using SharpArch.Domain.DomainModel;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain
{
    public interface IRoleBaseWithTypedId<TId,TUser,TUserId> : IEntityWithTypedId<TId>
        where TUser: UserBaseWithTypedId<TUserId>
    {
        string RoleName { get; set; }
        string ApplicationName { get; set; }
        IList<TUser> UsersInRole { get; set; }
    }
}