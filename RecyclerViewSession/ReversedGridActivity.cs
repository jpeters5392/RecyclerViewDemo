
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
	/// The only important thing here is that you pass "true" as the last parameter to the 
	/// GridLayoutManager to reverse the order that it renders the items
	/// </summary>
	[Activity(Label = "ReversedGridActivity")]
	public class ReversedGridActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Reversed Grid Layout";
		}

		protected override void AssignAdapter(IList<DemoModel> items)
		{
			adapter = new BasicGridAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new GridLayoutManager(this, 3, LinearLayoutManager.Vertical, true));
		}
	}
}

