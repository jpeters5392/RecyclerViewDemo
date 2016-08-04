
using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Models;
using RecyclerViewSession.Services;

namespace RecyclerViewSession
{
	public class BaseActivity : AppCompatActivity
	{
		protected RecyclerView demoRecyclerView;
		protected DemoService service;
		protected Android.Support.V7.Widget.Toolbar toolbar;

		protected virtual int LayoutId
		{
			get
			{
				return Resource.Layout.Main;
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(LayoutId);

			service = new DemoService();
			service.ResetData();

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

			//Toolbar will now take on default actionbar characteristics
			SetSupportActionBar(toolbar);

			demoRecyclerView = FindViewById<RecyclerView>(Resource.Id.demoRecyclerView);
		}

		protected override async void OnResume()
		{
			// since this is async void make sure to catch any exceptions
			try
			{
				base.OnResume();


				var items = await service.RetrieveAllItems();
				AssignAdapter(items);
				AssignDecorators();
				AddTouchHelpers();
				AssignLayoutManager();
			}
			catch(Exception ex)
			{
				Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
			}
		}

		protected virtual void AddTouchHelpers()
		{
			// the base version does not have touch helpers
		}

		protected virtual void AssignDecorators()
		{
			// the base version does not use decorators
		}

		protected virtual void AssignAdapter(IList<DemoModel> items)
		{
			var adapter = new BasicAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected virtual void AssignLayoutManager()
		{
			demoRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			service = null;

			if (demoRecyclerView != null)
			{
				demoRecyclerView.Dispose();
				demoRecyclerView = null;
			}

			if (toolbar != null)
			{
				toolbar.Dispose();
				toolbar = null;
			}
		}
	}
}

