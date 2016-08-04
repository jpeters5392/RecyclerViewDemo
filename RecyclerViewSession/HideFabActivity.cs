
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace RecyclerViewSession
{
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

