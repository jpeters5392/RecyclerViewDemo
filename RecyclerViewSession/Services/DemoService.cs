using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecyclerViewSession.Models;

namespace RecyclerViewSession.Services
{
	/// <summary>
	/// A dummy service to return data for the demo
	/// </summary>
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
			PopulateModel("Basic List", "http://images.clipshrine.com/wheel/thumb-Number-1-66.6-3874.png", typeof(MainActivity));
			PopulateModel("Horizontal List", "http://images.clipshrine.com/getimg/PngMedium-Number-2-3875.png", typeof(HorizontalListActivity));
			PopulateModel("Basic List with Dividers", "http://images.clipshrine.com/download/wheel/medium-Number-3-0-3876.png", typeof(DividerActivity));
			PopulateModel("Horizontal List with Dividers", "http://images.clipshrine.com/download/wheel/medium-Number-4-33.3-3878.png", typeof(HorizontalListWithDividersActivity));
			PopulateModel("List of Cards", "http://images.clipshrine.com/wheel/thumb-Number-5-0-3879.png", typeof(BasicCardActivity));
			PopulateModel("List of Swipeable Cards", "http://images.clipshrine.com/wheel/medium-Number-6-166.6-3880.png", typeof(SwipeableCardActivity));
			PopulateModel("Basic Grid", "http://images.clipshrine.com/wheel/medium-Number-7-0-3881.png", typeof(BasicGridActivity));
			PopulateModel("Reversed Grid", "http://images.clipshrine.com/download/wheel/medium-Number-8-33.3-3882.png", typeof(ReversedGridActivity));
			PopulateModel("Horizontal Grid", "http://images.clipshrine.com/getimg/PngMedium-Number-9-3883.png", typeof(HorizontalGridActivity));
			PopulateModel("Hide FAB", "https://openclipart.org/image/300px/svg_to_png/203546/number-10.png", typeof(HideFabActivity));
			PopulateModel("Disappearing Toolbar", "http://justclassics.wikispaces.com/file/view/red-rounded-with-number-11-md.png/347475496/red-rounded-with-number-11-md.png", typeof(DisappearingToolbarActivity));
			PopulateModel("Resizing Toolbar", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/12_white%2C_blue_rounded_rectangle.svg/325px-12_white%2C_blue_rounded_rectangle.svg.png", typeof(ResizeToolbarActivity));
		}
	}
}

