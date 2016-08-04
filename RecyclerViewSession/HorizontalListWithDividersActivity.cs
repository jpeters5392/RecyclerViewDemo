
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RecyclerViewSession.Adapters;

namespace RecyclerViewSession
{
	[Activity(Label = "HorizontalListWithDividersActivity")]
	public class HorizontalListWithDividersActivity : BaseActivity
	{
		DividerItemDecorator decorator;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Horizontal List with Dividers";
		}

		protected override void AssignAdapter(IList<Models.DemoModel> items)
		{
			var adapter = new HorizontalAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignDecorators()
		{
			decorator = new DividerItemDecorator(this, false);
			demoRecyclerView.AddItemDecoration(decorator);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false));
		}

		protected override void OnDestroy()
		{
			// be sure to clean up the decorator
			if (decorator != null)
			{
				if (demoRecyclerView != null)
				{
					demoRecyclerView.RemoveItemDecoration(decorator);
				}

				decorator.Dispose();
				decorator = null;
			}

			base.OnDestroy();
		}
	}
}

