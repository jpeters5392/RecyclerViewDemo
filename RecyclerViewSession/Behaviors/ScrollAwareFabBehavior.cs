using System;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;

namespace RecyclerViewSession
{
	/// <summary>
	/// This defines a behavior to be used with the CoordinatoryLayout where an item can be notified
	/// if other sibling items are scrolled.  We use this to hide/show the FAB as needed.
	/// </summary>
	// we need to reference this behavior from XML so we have to register this class to create a static key
	// otherwise you have to dig through your obj/ folder to find the Java wrapper package path for this class
	[Android.Runtime.Register("com.ilmservice.behaviors.ScrollAwareFabBehavior")]
	public class ScrollAwareFabBehavior : CoordinatorLayout.Behavior
	{
		public ScrollAwareFabBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int nestedScrollAxes)
		{
			// we are only interested in vertical scrolls
			return nestedScrollAxes == ViewCompat.ScrollAxisVertical || base.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, nestedScrollAxes);
		}

		public override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
		{
			base.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);

			var button = (FloatingActionButton)child;
			var recyclerView = target as RecyclerView;

			// this is where you could apply your custom logic to determine when the button is displayed
			if (recyclerView != null)
			{
				// if we are using a recyclerview with a linear layout manager then lets only show the button when the first element is fully visible
				var linearLayoutManager = recyclerView.GetLayoutManager() as LinearLayoutManager;
				if (linearLayoutManager != null)
				{
					var firstPosition = linearLayoutManager.FindFirstCompletelyVisibleItemPosition();
					if (firstPosition == 0)
					{
						button.Show();
					}
					else
					{
						button.Hide();
					}

					return;
				}
			}

			// otherwise if we don't have a subclass of LinearLayoutManager then hide the button on down scrolls and show on up scrolls
			if (dyConsumed > 0 && button.Visibility == ViewStates.Visible)
			{
				button.Hide();
			}
			else if (dyConsumed < 0 && button.Visibility != ViewStates.Visible)
			{
				button.Show();
			}
		}
	}
}

