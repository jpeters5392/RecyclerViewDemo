
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
		DividerItemDecorator decorator;

		protected override int LayoutId
		{
			get
			{
				return Resource.Layout.ResizeToolbarLayout;
			}
		}

		protected override void AssignDecorators()
		{
			decorator = new DividerItemDecorator(this, false);
			demoRecyclerView.AddItemDecoration(decorator);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Resize Toolbar";
		}

		protected override void OnDestroy()
		{
			// be sure to clean up the decorator
			if (decorator != null)
			{
				if (demoRecyclerView != null)
				{
					demoRecyclerView.RemoveItemDecoration(decorator);
				}

				decorator.Dispose();
				decorator = null;
			}

			base.OnDestroy();
		}
	}
}

