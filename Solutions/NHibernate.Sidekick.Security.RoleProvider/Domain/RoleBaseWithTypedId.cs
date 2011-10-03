using System;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain;
using SharpArch.Domain.DomainModel;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    public abstract class RoleBaseWithTypedId<TId> : EntityWithTypedId<TId>, IRoleBaseWithTypedId<TId>
    {
        public string RoleName { get; set; }
        public string ApplicationName { get; set; }
    } 
}
