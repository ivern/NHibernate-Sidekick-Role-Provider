using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Repositories
{
    public class RoleProviderRepository<T> : RoleProviderRepositoryWithTypedId<T, int>
        where T : RoleBase
    {}
}