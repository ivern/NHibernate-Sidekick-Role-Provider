using System;
using System.Linq;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Specifications;

namespace NHibernate.Sidekick.Security.RoleProvider.Tasks
{
    public class RoleProviderTaskWithTypedId<T, TId, TUser, TUserId> : IRoleProviderTaskWithTypedId<T, TId, TUser, TUserId>
        where T : RoleBaseWithTypedId<TId, TUser, TUserId> 
        where TUser: UserBaseWithTypedId<TUserId>
    {
        private readonly IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> roleProviderRepository;

        public RoleProviderTaskWithTypedId(IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> roleProviderRepository)
        {
            this.roleProviderRepository = roleProviderRepository;
        }

        public string[] GetUsersInRole(string roleName, string applicationName)
        {
            T role = GetRole(roleName, applicationName);
            return (from user in role.UsersInRole select user.Username).ToArray();
        }

        public void Delete(string roleName, string applicationName)
        {
            T role = GetRole(roleName, applicationName);
            Delete(role);
        }

        public void Delete(T role)
        {
            roleProviderRepository.Delete(role);
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch, string applicationName)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyUserInRole(string roleName, string applicationName)
        {
            T role = GetRole(roleName, applicationName);
            return role.UsersInRole.Count > 0;
        }

        public bool IsUserInRole(string username, string roleName, string applicationName)
        {
            T role = GetRole(roleName, applicationName);

            return role.UsersInRole.Where(x => x.Username == username).Count() != 0;
        }

        public void SaveOrUpdate(T role)
        {
            roleProviderRepository.SaveOrUpdate(role);
        }

        public string[] GetAllRoles(string applicationName)
        {
            return (from role in roleProviderRepository.FindAll(new RolesByApplicationName<T, TId, TUser, TUserId>(applicationName))
                    select role.RoleName).ToArray();
        }

        public T GetRole(string roleName, string applicationName)
        {
            return roleProviderRepository.FindOne(new RoleByRoleName<T, TId, TUser, TUserId>(applicationName, roleName));
        }

        public bool RoleExists(string roleName, string applicationName)
        {
            return roleProviderRepository
                       .FindAll(new RoleByRoleName<T, TId, TUser, TUserId>(applicationName, roleName))
                       .Count() > 0;
        }

        public string[] GetRolesForUser(string username, string applicationName)
        {
            string[] userRoles = roleProviderRepository.FindAll(new RolesByApplicationName<T, TId, TUser, TUserId>(applicationName))
                    .Where(r => r.UsersInRole.Where(u => u.Username.ToLower() == username.ToLower()).Any())
                    .Select(r => r.RoleName)
                    .ToArray();

            return userRoles;
        }
    }
}
