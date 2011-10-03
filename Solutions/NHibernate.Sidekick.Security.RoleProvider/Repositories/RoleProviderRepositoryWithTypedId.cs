using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Sidekick.Security.RoleProvider.Contracts.Repositories;
using NHibernate.Sidekick.Security.RoleProvider.Domain;
using SharpArch.NHibernate;

namespace NHibernate.Sidekick.Security.RoleProvider.Repositories
{
    public class RoleProviderRepositoryWithTypedId<T, TId> : LinqRepository<T>, IRoleProviderRepositoryWithTypedId<T,TId> 
        where T : RoleBaseWithTypedId<TId>
    {
    }
}
