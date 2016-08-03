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
		public Context Context { get; set; }

		public DividerItemDecorator()
		{
		}

		public DividerItemDecorator(Context context)
		{
			Context = context;
			divider = ContextCompat.GetDrawable(Context, Resource.Drawable.DividerItem);
		}

		public override void OnDrawOver(Canvas canvas, RecyclerView parent, RecyclerView.State state)
		{
			int left = parent.PaddingLeft;
			int right = parent.Width - parent.PaddingRight;

			int childCount = parent.ChildCount;
			for (int i = 0; i < childCount; i++)
			{
				View child = parent.GetChildAt(i);

				var layoutParams = (RecyclerView.LayoutParams)child.LayoutParameters;

				int top = child.Bottom + layoutParams.BottomMargin;
				int bottom = top + divider.IntrinsicHeight;

				divider.SetBounds(left, top, right, bottom);
				divider.Draw(canvas);
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

