﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Services;
using System;
using Android.Content;

namespace RecyclerViewSession
{
	[Activity(Label = "RecyclerViewSession", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		RecyclerView demoRecyclerView;
		Button activitySwitcher;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Title = "Basic Layout";

			demoRecyclerView = FindViewById<RecyclerView>(Resource.Id.demoRecyclerView);
			activitySwitcher = FindViewById<Button>(Resource.Id.activitySwitcher);
			activitySwitcher.Text = "Switch to Divider Demo";
			activitySwitcher.Click += SwitchToDividerActivity;
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
				demoRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
			}
			catch
			{
			}
		}

		protected void SwitchToDividerActivity(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(DividerActivity));
			StartActivity(intent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (activitySwitcher != null)
			{
				activitySwitcher.Click -= SwitchToDividerActivity;
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


