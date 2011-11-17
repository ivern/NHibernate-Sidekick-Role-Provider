NHibernate Sidekick's ASP.NET Role Provider
=================================================
This project is an implementation of the [ASP.NET Role Provider](http://msdn.microsoft.com/en-us/library/8fw7xh74.aspx) using [NHibernate](http://nhforge.org) and [Sharp Architecture](http://www.sharparchitecture.net/).

Implementation
---------------------
### 1. Create your `Role` entity
Create the entity responsible for persisting data between the Role Provider and your database.
<pre><code>public class User : NHibernate.Sidekick.Security.RoleProvider.Domain.RoleBase  { }
</code></pre>

This model assumes your `User`'s Identifier is an integer. If this is not the case, inherit from `RoleBaseWithTypedId<TId>` instead.

### 2. Create your provider
This is who unobtrusively does all the work for you.
<pre><code>public class MembershipProvider : NHibernate.Sidekick.Security.MembershipProvider.Providers.MembershipProvider&lt;User> { }
</code></pre>
This model assumes your `User`'s Identifier is an integer. If this is not the case, inherit from `MembershipProviderWithTypedId<T, TId>` instead.

### 3. Ignore `RoleBase` from Fluent NHibernate's Automap generator
<pre><code>public class AutoPersistenceModelGenerator : SharpArch.NHibernate.FluentNHibernate.IAutoPersistenceModelGenerator
{
	public AutoPersistenceModel Generate()
    {
		AutoPersistenceModel mappings = AutoMap.AssemblyOf&lt;User>(new AutomappingConfiguration());
		// Default Sharp Architecture options go here.		
		mappings.IgnoreBase&lt;UserBase>();
		mappings.IgnoreBase&lt;RoleBase>();
		mappings.IgnoreBase(typeof(UserBaseWithTypedId&lt;>));
		mappings.IgnoreBase(typeof(RoleBaseWithTypedId&lt;Role, User, int>));
	}
}
</code></pre>
This step is only relevant if you're using Fluent NHibernate's [Automapping mechanism](http://wiki.fluentnhibernate.org/Auto_mapping).

### 4. Implement NHibernate Sidekick's Membership Provider
See [﻿NHibernate Sidekick's ASP.NET Membership Provider](https://github.com/rebelliard/NHibernate-Sidekick-Membership-Provider).

### 5. Set your provider's configuration options
Set this within your application's `web.config`:
<pre><code>&lt;configuration>
	&lt;system.web>
		&lt;roleManager defaultProvider="SidekickRoleProvider" enabled="true" cacheRolesInCookie="true">
			&lt;providers>
				&lt;clear/>
				&lt;add    name="SidekickRoleProvider" 
						applicationName="/Sidekick_Security_SampleApp" 
						type="NHibernate.Sidekick.Security.Sampler.Domain.RoleProvider" />
			&lt;/providers>
		&lt;/roleManager>
	&lt;/system.web>
&lt;/configuration>
</code></pre>

Simple usage
-------------
<pre><code>@if (System.Web.Security.Roles.IsUserInRole("TestRole")) {
    &lt;text>User has the given role.!&lt;/text>
}
</pre></code>
<pre><code>[Authorize(Roles="TestRole")]
public class HomeController : Controller { }
</pre></code>
If you're unfamiliar with ASP.NET's Role Provider, you can find more information on Microsoft's [MSDN](http://msdn.microsoft.com/en-us/library/5k850zwb.aspx).

.NET Dependencies
------------------
* .NET Framework 4.0
* System
* System.Core
* System.Data
* System.Configuration
* System.Web
* System.Web.ApplicationServices

Third-Party Dependencies
-------------------------
* [NHibernate 3.1.0.4000](http://sourceforge.net/projects/nhibernate/files/NHibernate/)
* [Fluent NHibernate 1.2.0.712](http://fluentnhibernate.org/downloads)
* [Sharp Architecture 2.0.0.3 RC](https://github.com/sharparchitecture/Sharp-Architecture/downloads)
* [NHibernate Sidekick's ASP.NET Membership Provider](https://github.com/rebelliard/NHibernate-Sidekick-Membership-Provider)