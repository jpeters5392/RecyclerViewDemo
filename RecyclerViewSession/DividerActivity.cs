using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Services;
using System;
using Android.Content;

namespace RecyclerViewSession
{
	[Activity(Label="DividerActivity")]
	public class DividerActivity : Activity
	{
		RecyclerView demoRecyclerView;
		DividerItemDecorator decorator;
		Button activitySwitcher;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Title = "Divider RecyclerView";

			demoRecyclerView = FindViewById<RecyclerView>(Resource.Id.demoRecyclerView);
			activitySwitcher = FindViewById<Button>(Resource.Id.activitySwitcher);
			activitySwitcher.Text = "Switch to Basic Demo";
			activitySwitcher.Click += SwitchToMainActivity;
		}

		protected override async void OnResume()
		{
			// since this is async void make sure to catch any exceptions
			try
			{
				base.OnResume();

				var service = new DemoService();
				var adapter = new BasicAdapter();
				adapter.Items = await service.RetrieveAllItems();
				demoRecyclerView.SetAdapter(adapter);
				decorator = new DividerItemDecorator(this);
				demoRecyclerView.AddItemDecoration(decorator);
				demoRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
			}
			catch
			{
			}
		}

		protected void SwitchToMainActivity(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (decorator != null)
			{
				if (demoRecyclerView != null)
				{
					demoRecyclerView.RemoveItemDecoration(decorator);
				}

				decorator.Dispose();
				decorator = null;
			}

			if (activitySwitcher != null)
			{
				activitySwitcher.Click -= SwitchToMainActivity;
				activitySwitcher.Dispose();
				activitySwitcher = null;
			}

			if (demoRecyclerView != null)
			{
				demoRecyclerView.Dispose();
				demoRecyclerView = null;
			}
		}
	}
}


