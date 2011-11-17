using System.Linq;
using NHibernate.Sidekick.Security.MembershipProvider;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using SharpArch.Domain.Specifications;

namespace NHibernate.Sidekick.Security.RoleProvider.Specifications
{
    public abstract class RoleSpecificationBase<T, TId, TUser, TUserId> : ILinqSpecification<T>
        where T : RoleBaseWithTypedId<TId, TUser, TUserId>
        where TUser : UserBaseWithTypedId<TUserId>
    {
        protected readonly TId Id;
        protected readonly string RoleName;
        protected readonly string ApplicationName;

        protected RoleSpecificationBase(string applicationName, string roleName = null)
        {
            RoleName = roleName.ToLowerAndTrim();
            ApplicationName = applicationName;
        }

        protected RoleSpecificationBase(string applicationName, TId id, string roleName = null)
        {
            Id = id;
            RoleName = roleName.ToLowerAndTrim();
            ApplicationName = applicationName;
        }

        public abstract IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }
}