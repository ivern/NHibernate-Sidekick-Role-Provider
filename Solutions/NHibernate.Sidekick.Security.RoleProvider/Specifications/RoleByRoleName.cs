using System;
using System.Linq;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Specifications
{
    public class RoleByRoleName<T, TId, TUser, TUserId> : RoleSpecificationBase<T, TId, TUser, TUserId>
        where T : RoleBaseWithTypedId<TId, TUser, TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
        public RoleByRoleName(string applicationName, string roleName)
            : base(applicationName, roleName)
        {
        }

        public override IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            return candidates.Where(x => x.ApplicationName == ApplicationName && x.RoleName.ToLower() == RoleName);
        }
    }
}
