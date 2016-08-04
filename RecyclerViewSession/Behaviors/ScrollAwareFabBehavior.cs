using System;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;

namespace RecyclerViewSession
{
	// we need to reference this behavior from XML so register this class
	[Android.Runtime.Register("com.ilmservice.behaviors.ScrollAwareFabBehavior")]
	public class ScrollAwareFabBehavior : CoordinatorLayout.Behavior
	{
		public ScrollAwareFabBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int nestedScrollAxes)
		{
			return nestedScrollAxes == ViewCompat.ScrollAxisVertical || base.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, nestedScrollAxes);
		}

		public override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
		{
			base.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);

			var button = (FloatingActionButton)child;
			var recyclerView = target as RecyclerView;
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

			// otherwise hide the button on down scrolls and show on up scrolls
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

