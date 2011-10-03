using System;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Tasks
{
    public class RoleProviderTaskWithTypedId<T, TId, TUser, TUserId> : IRoleProviderTaskWithTypedId<T, TId, TUser, TUserId>
        where T : RoleBaseWithTypedId<TId,TUser,TUserId> 
        where TUser: UserBaseWithTypedId<TUserId>
    {
        private readonly IRoleProviderRepositoryWithTypedId<T,TId,TUser,TUserId> roleProviderRepository;

        public RoleProviderTaskWithTypedId(IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> roleProviderRepository)
        {
            this.roleProviderRepository = roleProviderRepository;
        }

        public string[] GetUsersInRole(string roleName, string applicationName)
        {
            throw new NotImplementedException();
        }

        public void Delete(string roleName)
        {
            throw new NotImplementedException();
        }

        public void Delete(T role)
        {
            throw new NotImplementedException();
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch, string applicationName)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyUserInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string username, object roleName, string applicationName)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(T role)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles(string applicationName)
        {
            throw new NotImplementedException();
        }

        public T GetRole(string roleName, string applicationName)
        {
            throw new NotImplementedException();
        }

        public string[] GetRolesForUser(string username, string applicationName)
        {
            throw new NotImplementedException();
        }
    }
}