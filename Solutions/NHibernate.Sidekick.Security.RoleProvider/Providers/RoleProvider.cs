using NHibernate.Sidekick.Security.RoleProvider.Domain;

namespace NHibernate.Sidekick.Security.RoleProvider.Providers
{
    public abstract class RoleProvider<T> : RoleProviderWithTypedId<T, int>
        where T : RoleBase, new()
    {
    }
}

