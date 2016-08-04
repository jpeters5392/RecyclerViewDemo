
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
	/// <summary>
	/// The important thing when dealing with swipe gestures is the ItemTouchHelper object.
	/// That class determines what happens when you attempt to move or swipe an item, 
	/// and it also determines when that item is considered fully "swiped"
	/// </summary>
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
			// you have to specify a callback for the helper to use
			// and then you attach the helper to the recyclerview
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

