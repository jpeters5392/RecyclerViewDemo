using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;

namespace RecyclerViewSession
{
	public class DividerItemDecorator : RecyclerView.ItemDecoration
	{
		Drawable divider;
		bool addDecoratorToLastItem = false;
		public Context Context { get; set; }

		public DividerItemDecorator(Context context, bool addDecoratorToLastItem)
		{
			Context = context;
			divider = ContextCompat.GetDrawable(Context, Resource.Drawable.DividerItem);
			this.addDecoratorToLastItem = addDecoratorToLastItem;
		}

		public override void OnDrawOver(Canvas cValue, RecyclerView parent, RecyclerView.State state)
		{
			int left = parent.PaddingLeft;
			int right = parent.Width - parent.PaddingRight;

			int childCount = parent.ChildCount;

			// if you want to add the divider to the last item then the modifier should be 0
			int modifier = addDecoratorToLastItem ? 0 : 1;
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

		protected override void Dispose(bool disposing)
		{
			Context = null;

			if (divider != null)
			{
				divider.Dispose();
				divider = null;
			}

			base.Dispose(disposing);
		}
	}
}

