
using System;

using Android.App;
using Android.OS;

namespace RecyclerViewSession
{
	/// <summary>
	/// All of the work to get the toolbar to collapse when you scroll is handled in the layout file
	/// </summary>
	[Activity(Label = "DisappearingToolbarActivity")]
	public class DisappearingToolbarActivity : BaseActivity
	{
		protected override int LayoutId
		{
			get
			{
				return Resource.Layout.DisappearingToolbarLayout;
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Disappearing Toolbar";
		}
	}
}

