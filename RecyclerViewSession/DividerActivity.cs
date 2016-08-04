using Android.App;
using Android.OS;

namespace RecyclerViewSession
{
	[Activity(Label="DividerActivity")]
	public class DividerActivity : BaseActivity
	{
		DividerItemDecorator decorator;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Divider RecyclerView";
		}

		protected override void AssignDecorators()
		{
			decorator = new DividerItemDecorator(this, false);
			demoRecyclerView.AddItemDecoration(decorator);
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


