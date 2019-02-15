using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;
using System.Web.Routing;

namespace LOC.Cache.Business.Initialization
{
	[InitializableModule]
	[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
	public class LocalObjectCacheInitialzationModule : IInitializableModule
	{
		private bool initialized = false;

		public void Initialize(InitializationEngine context)
		{
			if (!initialized)
			{
				RouteTable.Routes.MapRoute(
					name: "LocalObjectCache",
					url: "localobjectcache/{action}", 
					defaults: new { controller = "LocalObjectCache", action = "Index" });
			}
		}

		public void Uninitialize(InitializationEngine context) { }
	}
}