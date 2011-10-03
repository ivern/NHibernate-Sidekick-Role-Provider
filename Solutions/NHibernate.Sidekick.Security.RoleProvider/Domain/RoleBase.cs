using System;

namespace NHibernate.Sidekick.Security.RoleProvider.Domain
{
    [Serializable]
    public abstract class RoleBase : RoleBaseWithTypedId<int>
    {}
}