using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration.Provider;
using NHibernate.Sidekick.Security.MembershipProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.MembershipProvider.Contracts.Tasks;
using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.MembershipProvider.Repositories;
using NHibernate.Sidekick.Security.MembershipProvider.Tasks;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Tasks;

namespace NHibernate.Sidekick.Security.RoleProvider.Providers
{
    public class RoleProviderWithTypedId<T, TId, TUser, TUserId> : System.Web.Security.RoleProvider 
        where T : RoleBaseWithTypedId<TId, TUser, TUserId>, new()
        where TUser : UserBaseWithTypedId<TUserId>
    {
        #region Private
        private readonly IRoleProviderTaskWithTypedId<T, TId, TUser, TUserId> roleProviderTask;
        private readonly IMembershipProviderTaskWithTypedId<TUser, TUserId> membershipProviderTask;
        #endregion

        protected RoleProviderWithTypedId()
        {
            roleProviderTask = new RoleProviderTaskWithTypedId<T, TId, TUser, TUserId>(new RoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId>());
            membershipProviderTask = new MembershipProviderTaskWithTypedId<TUser, TUserId>(new MembershipProviderRepositoryWithTypedId<TUser, TUserId>());
        }

        protected RoleProviderWithTypedId(IRoleProviderRepositoryWithTypedId<T, TId, TUser, TUserId> roleRepository, IMembershipProviderRepositoryWithTypedId<TUser, TUserId>  membershipRepository)
        {
            roleProviderTask = new RoleProviderTaskWithTypedId<T, TId, TUser, TUserId>(roleRepository);
            membershipProviderTask = new MembershipProviderTaskWithTypedId<TUser, TUserId>(membershipRepository);
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name.Length == 0)
                name = "SidekickRoleProvider";

            if (String.IsNullOrWhiteSpace(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Sidekick's Role Provider");
            }

            base.Initialize(name, config);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return roleProviderTask.IsUserInRole(username, roleName, ApplicationName);
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = roleProviderTask.GetRolesForUser(username, ApplicationName);
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            if (roleName.Contains(","))
                throw new ArgumentException("Role names cannot contain commas.");

            if (RoleExists(roleName))
                throw new ProviderException("Role name already exists.");

            T role = new T
                         {
                             ApplicationName = ApplicationName, 
                             RoleName = roleName
                         };

            roleProviderTask.SaveOrUpdate(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (!RoleExists(roleName))
                throw new ProviderException("Role does not exist.");

            if (throwOnPopulatedRole && roleProviderTask.IsAnyUserInRole(roleName))
                throw new ProviderException("Cannot delete a populated role.");

            roleProviderTask.Delete(roleName);

            return true;
        }

        public override bool RoleExists(string roleName)
        {
            T role = roleProviderTask.GetRole(roleName, ApplicationName);
            return role != null;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            string unexistingRole = roleNames.FirstOrDefault(roleName => !RoleExists(roleName));

            if (unexistingRole != null)
                throw new ProviderException(String.Format("Role name {0} not found.", unexistingRole));

            List<T> rolesFetched = new List<T>();
            foreach (string username in usernames)
            {
                if (username.Contains(","))
                    throw new ArgumentException(String.Format("User names {0} cannot contain commas.", username));

                string existingRole = roleNames.FirstOrDefault(roleName => IsUserInRole(username, roleName));
                if (existingRole != null)
                    throw new ProviderException(String.Format("User {0} is already in role {1}.", username, existingRole));

                TUser user = membershipProviderTask.Get(username, ApplicationName);
                if (user != null)
                {
                    foreach (string roleName in roleNames)
                    {
                        T role = rolesFetched.FirstOrDefault(x => x.RoleName == roleName);

                        if (role == null)
                        {
                            role = roleProviderTask.GetRole(roleName, ApplicationName);
                            rolesFetched.Add(role);
                        }

                        role.UsersInRole.Add(user);
                        roleProviderTask.SaveOrUpdate(role);
                    }
                }
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            string[] users = roleProviderTask.GetUsersInRole(roleName, ApplicationName);
            return users;
        }

        public override string[] GetAllRoles()
        {
            string[] roleNames = roleProviderTask.GetAllRoles(ApplicationName);
            return roleNames;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            string[] users = roleProviderTask.FindUsersInRole(roleName, usernameToMatch, ApplicationName);
            return users;
        }

        public override string ApplicationName { get; set; }

        #region Helper Functions
        private string GetConfigurationValue(string configValue, string defaultValue)
        {
            return String.IsNullOrWhiteSpace(configValue) ? defaultValue : configValue;
        }

        #endregion
    }
}