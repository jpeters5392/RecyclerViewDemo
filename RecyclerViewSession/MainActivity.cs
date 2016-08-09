using Android.App;
using Android.OS;
using Android.Views;

namespace RecyclerViewSession
{
	// You don't have to do anything special for a basic list
	[Activity(Label = "RecyclerViewSession", MainLauncher = false)]
	public class MainActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Basic Layout";
		}
	}
}


