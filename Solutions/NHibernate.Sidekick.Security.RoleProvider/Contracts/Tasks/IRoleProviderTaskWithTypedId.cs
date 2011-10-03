using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks
{
    public interface IRoleProviderTaskWithTypedId<in T, TId> where T : RoleBaseWithTypedId<TId>
    {
        void SaveOrUpdate(T role);
    }
}