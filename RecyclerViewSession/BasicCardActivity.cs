
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Models;

namespace RecyclerViewSession
{
	[Activity(Label = "BasicCardActivity")]
	public class BasicCardActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Basic Card RecyclerView";
		}

		protected override void AssignAdapter(IList<DemoModel> items)
		{
			var adapter = new CardAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}
	}
}

