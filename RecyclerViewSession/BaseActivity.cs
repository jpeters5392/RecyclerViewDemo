
using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Newtonsoft.Json;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Models;
using RecyclerViewSession.Services;

namespace RecyclerViewSession
{
	/// <summary>
	/// This is a base class that populates the recycler view with data.
	/// Using this allows the different activities to only do what is unique to that specific demo
	/// </summary>
	public class BaseActivity : AppCompatActivity
	{
		protected IList<DemoModel> items;
		protected const string ItemsCacheKey = "itemsCache";

		protected RecyclerView demoRecyclerView;
		protected DemoService service;
		protected Android.Support.V7.Widget.Toolbar toolbar;
		protected BasicAdapter adapter;

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

			// set the support action toolbar to be the toolbar widget in our view
			SetSupportActionBar(toolbar);

			demoRecyclerView = FindViewById<RecyclerView>(Resource.Id.demoRecyclerView);

			// if there is saved state, then restore it here so that scrolling position can be retained
			if (savedInstanceState != null)
			{
				var cachedItems = savedInstanceState.GetString(ItemsCacheKey, null);
				if (cachedItems != null)
				{
					items = JsonConvert.DeserializeObject<IList<DemoModel>>(cachedItems);
					BuildRecyclerView(items);
				}
			}
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

			outState.PutString(ItemsCacheKey, JsonConvert.SerializeObject(items));
		}

		protected override async void OnResume()
		{
			// since this is async void make sure to catch any exceptions
			try
			{
				base.OnResume();

				if (items == null)
				{
					items = await service.RetrieveAllItems();
					BuildRecyclerView(items);
				}
			}
			catch(Exception ex)
			{
				Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
			}
		}

		protected virtual void BuildRecyclerView(IList<DemoModel> items)
		{
			AssignAdapter(items);
			AssignDecorators();
			AddTouchHelpers();
			AssignLayoutManager();
		}

		protected virtual void AddTouchHelpers()
		{
			// the basic version does not have touch helpers
		}

		protected virtual void AssignDecorators()
		{
			// the basic version does not use decorators
		}

		protected virtual void AssignAdapter(IList<DemoModel> items)
		{
			// use a simple adapter for the basic version, but let subclasses override this
			adapter = new BasicAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected virtual void AssignLayoutManager()
		{
			// use a linear layout by default, but make this overridable by subclasses
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

			if (adapter != null)
			{
				adapter.Dispose();
				adapter = null;
			}

			if (toolbar != null)
			{
				toolbar.Dispose();
				toolbar = null;
			}
		}
	}
}

