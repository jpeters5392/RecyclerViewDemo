
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
using RecyclerViewSession.Models;

namespace RecyclerViewSession
{
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
			var adapter = new BasicGridAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new GridLayoutManager(this, 3, LinearLayoutManager.Horizontal, false));
		}
	}
}

