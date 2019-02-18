using System.Linq;
using System.Web.Mvc;
using LOC.Cache.Models.ViewModels;
using EPiServer.PlugIn;
using System.Collections;
using EPiServer.Core;
using EPiServer;

namespace LOC.Cache.Controllers
{
	[Authorize(Roles = "CmsAdmins")]
	[GuiPlugIn(Area = PlugInArea.AdminMenu, Url = "~/localobjectcache", DisplayName = "Clear Local Object Cache")]
    public class LocalObjectCacheController : Controller
    {
        // GET: ObjectCache
        public ActionResult Index(string FilteredBy)
        {
			var viewmodel = new LocalObjectCacheViewModel();

			var cachedEntries = HttpContext.Cache.Cast<DictionaryEntry>();

			switch (FilteredBy)
			{
				case "pages":
					viewmodel.CachedItems = cachedEntries.Where(item => item.Value is PageData);
					break;
				case "content":
					viewmodel.CachedItems = cachedEntries.Where(item => item.Value is IContent);
					break;
				default:
					viewmodel.CachedItems = cachedEntries;
					break;
			}

			viewmodel.FilteredBy = FilteredBy;

			viewmodel.Choices = new[]
			{
				new SelectListItem { Text = "All Cached Objects", Value = "all" },
				new SelectListItem { Text = "Any Content", Value = "content" },
				new SelectListItem { Text = "Pages Only", Value = "pages" }
			};

            return View("~/Features/LocalObjectCache/index.cshtml", viewmodel);
        }

		public ActionResult RemoveLocalCache(string[] cacheKey)
		{
			if (cacheKey != null)
			{
				foreach (string key in cacheKey)
				{
					CacheManager.RemoveLocalOnly(key);
				}
			}
			return RedirectToAction("Index");
		}
    }
}