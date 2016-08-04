
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
	/// Use the GridLayoutManager to create a grid from the RecyclerView
	/// </summary>
	[Activity(Label = "BasicGridActivity")]
	public class BasicGridActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Basic Grid Layout";
		}

		protected override void AssignAdapter(IList<DemoModel> items)
		{
			var adapter = new BasicGridAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new GridLayoutManager(this, 3));
		}
	}
}

