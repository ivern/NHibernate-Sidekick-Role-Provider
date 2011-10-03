using NHibernate.Sidekick.Security.MembershipProvider.Domain;
using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks
{
    public interface IRoleProviderTaskWithTypedId<T, TId, TUser, TUserId> 
        where TUser : UserBaseWithTypedId<TUserId>
    {
        string[] FindUsersInRole(string roleName, string usernameToMatch, string applicationName);
        bool IsAnyUserInRole(string roleName);
        bool IsUserInRole(string username, object roleName, string applicationName);
        string[] GetAllRoles(string ApplicationName);
        T GetRole(string roleName, string applicationName);
        string[] GetRolesForUser(string username, string applicationName);
        string[] GetUsersInRole(string roleName, string applicationName);
        void Delete(string roleName);
        void Delete(T role);
        void SaveOrUpdate(T role);
    }
}