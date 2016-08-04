
using System;

using Android.App;
using Android.OS;


namespace RecyclerViewSession
{
	/// <summary>
	/// All of the work to get a toolbar to resize is handled in the layout file.
	/// </summary>
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

