using NHibernate.Sidekick.Security.MembershipProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Contracts.Tasks
{
    public interface IRoleProviderTaskWithTypedId<T, TId, TUser, TUserId> 
        where TUser : UserBaseWithTypedId<TUserId>
    {
        string[] FindUsersInRole(string roleName, string usernameToMatch, string applicationName);
        bool IsAnyUserInRole(string roleName, string applicationName);
        bool IsUserInRole(string username, string roleName, string applicationName);
        string[] GetAllRoles(string applicationName);
        T GetRole(string roleName, string applicationName);
        bool RoleExists(string roleName, string applicationName);
        string[] GetRolesForUser(string username, string applicationName);
        string[] GetUsersInRole(string roleName, string applicationName);
        void Delete(string roleName, string applicationName);
        void Delete(T role);
        void SaveOrUpdate(T role);
    }
}