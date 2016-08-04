
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget.Helper;
using RecyclerViewSession.Adapters;
using RecyclerViewSession.Models;
using RecyclerViewSession.TouchHelpers;

namespace RecyclerViewSession
{
	[Activity(Label = "SwipeableCardActivity")]
	public class SwipeableCardActivity : BaseActivity
	{
		ItemTouchHelper itemTouchHelper;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Swipeable Card RecyclerView";
		}

		protected override void AssignAdapter(IList<DemoModel> items)
		{
			var adapter = new SwipeableCardAdapter();
			adapter.Items = items;
			demoRecyclerView.SetAdapter(adapter);
		}

		protected override void AddTouchHelpers()
		{
			var swipeHelper = new SwipeToDismissCallback();
			itemTouchHelper = new ItemTouchHelper(swipeHelper);
			itemTouchHelper.AttachToRecyclerView(demoRecyclerView);
		}

		protected override void OnDestroy()
		{
			if (itemTouchHelper != null)
			{
				itemTouchHelper.Dispose();
				itemTouchHelper = null;
			}

			base.OnDestroy();
		}
	}
}

