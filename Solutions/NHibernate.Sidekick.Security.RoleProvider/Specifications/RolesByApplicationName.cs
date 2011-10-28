using System.Linq;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Specifications
{
    public class RolesByApplicationName<T, TId, TUser, TUserId> : RoleSpecificationBase<T, TId, TUser, TUserId>
        where T : RoleBaseWithTypedId<TId, TUser, TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
        public RolesByApplicationName(string applicationName)
            : base(applicationName)
        {
        }

        public override IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            return candidates.Where(x => x.ApplicationName == ApplicationName);
        }
    }
}
