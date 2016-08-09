
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Models;

namespace RecyclerViewSession
{
	/// <summary>
	/// You have to specify the horizontal orientation with the layout manager
	/// </summary>
	[Activity(Label = "HorizontalGridActivity")]
	public class HorizontalGridActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Horizontal Grid Layout";
		}

		protected override void AssignAdapter(IList<DemoModel> items)
		{
			adapter = new BasicGridAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new GridLayoutManager(this, 3, LinearLayoutManager.Horizontal, false));
		}
	}
}

