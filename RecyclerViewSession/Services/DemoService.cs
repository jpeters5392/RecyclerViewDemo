using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecyclerViewSession.Models;

namespace RecyclerViewSession.Services
{
	public class DemoService
	{
		static IList<DemoModel> items;
		public DemoService()
		{
			if (items == null)
			{
				items = new List<DemoModel>();
				PopulateModel("Joel Peterson", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png"); 
				PopulateModel("Dan Edgar", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/dan-edgar-116.png");
				PopulateModel("Brian Maula", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/brian-maula-100.png");
				PopulateModel("Brett Hazen", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/brett-hazen-106.png");
			}
		}

		public Task<IList<DemoModel>> RetrieveAllItems()
		{
			// return a Task to mimic a real world service
			return Task.Run(() => items);
		}

		void PopulateModel(string name, string url)
		{
			var model = new DemoModel();
			model.Name = name;
			model.ImageUrl = url;
			items.Add(model);
		}
	}
}

