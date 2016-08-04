
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

