using System;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Tasks
{
    public class RoleProviderTaskWithTypedId<T,TId> : IRoleProviderTaskWithTypedId<T, TId> where T : RoleBaseWithTypedId<TId>
    {
        private readonly IRoleProviderRepositoryWithTypedId<T,TId> roleProviderRepository;

        public RoleProviderTaskWithTypedId(IRoleProviderRepositoryWithTypedId<T, TId> roleProviderRepository)
        {
            this.roleProviderRepository = roleProviderRepository;
        }

        public void SaveOrUpdate(T role)
        {
            throw new NotImplementedException();
        }
    }
}