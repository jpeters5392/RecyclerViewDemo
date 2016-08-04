using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RecyclerViewSession.Events;

namespace RecyclerViewSession.ViewHolders
{
	public class BasicViewHolder : RecyclerView.ViewHolder
	{
		public TextView BasicLayoutText { get; set; }
		public ImageView BasicLayoutImage { get; set; }
		public Button SwitchToDemo { get; set; }

		public event EventHandler<ViewHolderEventArgs> DemoChanged;

		public BasicViewHolder(View v) : base(v)
		{
			BasicLayoutText = v.FindViewById<TextView>(Resource.Id.basicLayoutText);
			BasicLayoutImage = v.FindViewById<ImageView>(Resource.Id.basicLayoutImage);
			SwitchToDemo = v.FindViewById<Button>(Resource.Id.switchToDemo);
			SwitchToDemo.Click += OnClickSwitchToDemo;
		}

		protected void OnClickSwitchToDemo(object sender, EventArgs e)
		{
			DemoChanged?.Invoke(this, new ViewHolderEventArgs(AdapterPosition));
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

			if (SwitchToDemo != null)
			{
				SwitchToDemo.Click -= OnClickSwitchToDemo;
				SwitchToDemo.Dispose();
				SwitchToDemo = null;
			}

			base.Dispose(disposing);
		}
	}
}

