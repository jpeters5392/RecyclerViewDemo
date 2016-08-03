using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RecyclerViewSession.ViewHolders
{
	public class BasicViewHolder : RecyclerView.ViewHolder
	{
		public TextView BasicLayoutText { get; set; }
		public ImageView BasicLayoutImage { get; set; }

		public BasicViewHolder(View v) : base(v)
		{
			BasicLayoutText = v.FindViewById<TextView>(Resource.Id.basicLayoutText);
			BasicLayoutImage = v.FindViewById<ImageView>(Resource.Id.basicLayoutImage);
		}

		protected override void Dispose(bool disposing)
		{
			if (BasicLayoutImage != null)
			{
				BasicLayoutImage.Dispose();
				BasicLayoutImage = null;
			}

			if (BasicLayoutText != null)
			{
				BasicLayoutText.Dispose();
				BasicLayoutText = null;
			}

			base.Dispose(disposing);
		}
	}
}

