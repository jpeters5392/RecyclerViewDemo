
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace RecyclerViewSession
{
	[Activity(Label = "ResizeToolbarActivity")]
	public class ResizeToolbarActivity : BaseActivity
	{
		protected override int LayoutId
		{
			get
			{
				return Resource.Layout.ResizeToolbarLayout;
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Resize Toolbar";
		}
	}
}

