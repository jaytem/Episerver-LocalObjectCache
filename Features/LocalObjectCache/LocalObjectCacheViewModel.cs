using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LOC.Cache.Models.ViewModels
{
	public class LocalObjectCacheViewModel
	{
		public IEnumerable<DictionaryEntry> CachedItems { get; set; }
		public string FilteredBy { get; set; }

		public IEnumerable<SelectListItem> Choices { get; set; }
	}
}