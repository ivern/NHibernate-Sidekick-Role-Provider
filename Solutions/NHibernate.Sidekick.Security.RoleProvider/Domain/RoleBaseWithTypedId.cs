using System;
using System.Collections.Generic;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Domain;
using SharpArch.Domain.DomainModel;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    public abstract class RoleBaseWithTypedId<TId,TUser,TUserId> : EntityWithTypedId<TId>, IRoleBaseWithTypedId<TId, TUser,TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
        protected RoleBaseWithTypedId()
        {
            UsersInRole = new List<TUser>();
        }

        public string RoleName { get; set; }
        public string ApplicationName { get; set; }
        public IList<TUser> UsersInRole { get; set; }
    } 
}
