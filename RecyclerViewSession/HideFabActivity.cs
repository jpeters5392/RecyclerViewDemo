
using System;

using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;

namespace RecyclerViewSession
{
	/// <summary>
	/// The logic to hide the FAB is handled in the behavior registed in the layout file.
	/// A reference to the FAB is only needed here to handle click events.
	/// </summary>
	[Activity(Label = "HideFabActivity")]
	public class HideFabActivity : BaseActivity
	{
		FloatingActionButton fab;

		protected override int LayoutId
		{
			get
			{
				return Resource.Layout.FabLayout;
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Hide FAB";

			fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.Click += FabClicked;
		}

		protected void FabClicked(object sender, EventArgs e)
		{
			Toast.MakeText(this, "Clicked FAB", ToastLength.Short).Show();
		}

		protected override void OnDestroy()
		{
			if (fab != null)
			{
				fab.Click -= FabClicked;
				fab.Dispose();
				fab = null;
			}

			base.OnDestroy();
		}
	}
}

