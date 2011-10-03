using System;
using System.Collections.Generic;
using SharpArch.Domain.DomainModel;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain
{
    public interface IRoleBaseWithTypedId<TId> : IEntityWithTypedId<TId>
    {
        string RoleName { get; set; }
        string ApplicationName { get; set; }
        //IList<Users> UsersInRole { get; set; }
    }
}