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
				InitializeDataSet();
			}
		}

		public Task<IList<DemoModel>> RetrieveAllItems()
		{
			// return a Task to mimic a real world service
			return Task.Run(() => items);
		}

		public Task<bool> RemoveItem(DemoModel item)
		{
			return Task.Run(() => items.Remove(item));
		}

		public void ResetData()
		{
			InitializeDataSet();
		}

		void PopulateModel(string name, string url, Type activityType)
		{
			var model = new DemoModel();
			model.Name = name;
			model.ImageUrl = url;
			model.ActivityType = activityType;
			items.Add(model);
		}

		void InitializeDataSet()
		{
			items = new List<DemoModel>();
			PopulateModel("Basic List", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png", typeof(MainActivity));
			PopulateModel("Basic List with Dividers", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/dan-edgar-116.png", typeof(DividerActivity));
			PopulateModel("List of Cards", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/brian-maula-100.png", typeof(BasicCardActivity));
			PopulateModel("List of Swipeable Cards", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/brett-hazen-106.png", typeof(SwipeableCardActivity));
			PopulateModel("Hide FAB", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/jason-erdahl-289.jpg", typeof(HideFabActivity));
			PopulateModel("Resizing Toolbar", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png", typeof(MainActivity));
			PopulateModel("Basic Grid", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png", typeof(BasicGridActivity));
			PopulateModel("Scroll Indexing", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png", typeof(BasicGridActivity));
			PopulateModel("Grid with Headers", "https://ilmwebsitestorage.blob.core.windows.net/profile-images/joel-peterson-112.png", typeof(BasicGridActivity));
		}
	}
}

