using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V7.Widget;
using Android.Views;

namespace RecyclerViewSession
{
	/// <summary>
	/// An item decorator that draws a 1dp divider between the items
	/// </summary>
	public class DividerItemDecorator : RecyclerView.ItemDecoration
	{
		Drawable divider;
		bool addDecoratorToLastItem = false;
		public Context Context { get; set; }

		public DividerItemDecorator(Context context, bool addDecoratorToLastItem)
		{
			Context = context;

			// Grab a reference to the divider here.
			// You can tint it or manipulate it if you want.
			// NOTE: All references to a given drawable share the same instance, 
			// so if you want to do something specific to this decorator then call Mutate() on it
			// to get a unique instance
			divider = ContextCompat.GetDrawable(Context, Resource.Drawable.DividerItem);
			divider = DrawableCompat.Wrap(divider);
			DrawableCompat.SetTint(divider, ContextCompat.GetColor(Context, Resource.Color.dividerColor));
			DrawableCompat.SetTintMode(divider, PorterDuff.Mode.SrcIn);
			divider.Alpha = 125;
			this.addDecoratorToLastItem = addDecoratorToLastItem;
		}

		/// <summary>
		/// These are drawn on to the canvas AFTER the view, so they will appear on top of any content.
		/// Use OnDraw(...) to draw underneath the content view
		/// </summary>
		/// <param name="cValue">C value.</param>
		/// <param name="parent">Parent.</param>
		/// <param name="state">State.</param>
		public override void OnDrawOver(Canvas cValue, RecyclerView parent, RecyclerView.State state)
		{
			int childCount = parent.ChildCount;

			// our decorator only cares about RecyclerViews that use a layout manager descending from the LinearLayoutManager
			var layoutManager = parent.GetLayoutManager() as LinearLayoutManager;
			if (layoutManager != null && layoutManager.Orientation == LinearLayoutManager.Vertical)
			{
				// draw the horizontal divider underneath the item
				int left = parent.PaddingLeft;
				int right = parent.Width - parent.PaddingRight;

				// if you want to add the divider to the last item then the modifier should be 0
				int modifier = 0;
				if (!addDecoratorToLastItem && DetermineIfItemIsLastItem(layoutManager))
				{
					modifier = 1;
				}

				for (int i = 0; i < childCount - modifier; i++)
				{
					View child = parent.GetChildAt(i);

					var layoutParams = (RecyclerView.LayoutParams)child.LayoutParameters;

					int top = child.Bottom + layoutParams.BottomMargin;
					int bottom = top + divider.IntrinsicHeight;

					divider.SetBounds(left, top, right, bottom);
					divider.Draw(cValue);
				}
			}
			else if (layoutManager != null && layoutManager.Orientation == LinearLayoutManager.Horizontal)
			{
				// draw the vertical divider to the right of the item
				int top = parent.PaddingTop;
				int bottom = parent.Height - parent.PaddingBottom;

				// if you want to add the divider to the last item then the modifier should be 0
				int modifier = 0;
				if (!addDecoratorToLastItem && DetermineIfItemIsLastItem(layoutManager))
				{
					modifier = 1;
				}

				for (int i = 0; i < childCount - modifier; i++)
				{
					View child = parent.GetChildAt(i);

					var layoutParams = (RecyclerView.LayoutParams)child.LayoutParameters;

					int left = child.Right + layoutParams.RightMargin;
					int right = left + divider.IntrinsicWidth;

					divider.SetBounds(left, top, right, bottom);
					divider.Draw(cValue);
				}
			}
		}

		/// <summary>
		/// Determines if the last visible item is the absolute last item in the data set
		/// </summary>
		/// <returns><c>true</c>, if the last visible item is the absolute last item, <c>false</c> otherwise.</returns>
		/// <param name="layoutManager">Layout manager.</param>
		bool DetermineIfItemIsLastItem(LinearLayoutManager layoutManager)
		{
			// check to see if the last visible item is the absolute last item
			if (layoutManager.FindLastVisibleItemPosition() == layoutManager.ItemCount - 1)
			{
				return true;
			}

			return false;
		}

		protected override void Dispose(bool disposing)
		{
			Context = null;

			// be sure to clean up the drawable instance
			if (divider != null)
			{
				divider.Dispose();
				divider = null;
			}

			base.Dispose(disposing);
		}
	}
}

