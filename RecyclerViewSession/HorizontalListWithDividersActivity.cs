
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using RecyclerViewSession.Adapters;

namespace RecyclerViewSession
{
	/// <summary>
	/// You have to specify the horizontal orientation with the layout manager, and then 
	/// you also have to attach the ItemDecorator that creates the divider
	/// </summary>
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
			adapter = new HorizontalAdapter();
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

