using System;
using System.Collections.Generic;
using System.Diagnostics;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain;
using SharpArch.Domain.DomainModel;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    [DebuggerDisplay("{RoleName}")]
    public abstract class RoleBaseWithTypedId<TId, TUser, TUserId> : EntityWithTypedId<TId>, IRoleBaseWithTypedId<TId, TUser, TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
        protected RoleBaseWithTypedId()
        {
            UsersInRole = new List<TUser>();
        }

        public virtual string RoleName { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual IList<TUser> UsersInRole { get; set; }
    } 
}
