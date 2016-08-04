
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using RecyclerViewSession.Adapters;

namespace RecyclerViewSession
{
	/// <summary>
	/// You have to specify the horizontal orientation with the layout manager
	/// </summary>
	[Activity(Label = "HorizontalListActivity")]
	public class HorizontalListActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Horizontal List Layout";
		}

		protected override void AssignAdapter(IList<Models.DemoModel> items)
		{
			var adapter = new HorizontalAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false));
		}
	}
}

