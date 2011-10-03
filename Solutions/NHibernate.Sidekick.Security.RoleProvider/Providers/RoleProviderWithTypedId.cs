using System;
using System.Configuration;
using System.Configuration.Provider;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Tasks;

namespace NHibernate.Sidekick.Security.RoleProvider.Providers
{
    public class RoleProviderWithTypedId<T, TId> : System.Web.Security.RoleProvider where T : RoleBaseWithTypedId<TId>, new()
    {
        #region Private
        private readonly RoleProviderTaskWithTypedId<T, TId> roleProviderTask;
        #endregion

        protected RoleProviderWithTypedId()
        {
            roleProviderTask = new RoleProviderTaskWithTypedId<T, TId>(new RoleProviderRepositoryWithTypedId<T, TId>());
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

            // Initialize the abstract base class.
            base.Initialize(name, config);
        }

        protected RoleProviderWithTypedId(IRoleProviderRepositoryWithTypedId<T, TId> repository)
        {
            roleProviderTask = new RoleProviderTaskWithTypedId<T, TId>(repository);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
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