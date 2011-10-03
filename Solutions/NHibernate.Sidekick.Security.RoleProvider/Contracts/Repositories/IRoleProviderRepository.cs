using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories
{
    public interface IRoleProviderRepository<T> : IRoleProviderRepositoryWithTypedId<T,int>
        where T : RoleBase 
    {}
}
