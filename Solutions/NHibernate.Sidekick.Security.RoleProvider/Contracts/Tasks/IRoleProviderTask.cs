using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks
{
    public interface IRoleProviderTask<in T> : IRoleProviderTaskWithTypedId<T, int>
        where T : RoleBaseWithTypedId<int>
    {
    }
}