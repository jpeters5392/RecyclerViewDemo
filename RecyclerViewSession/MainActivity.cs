using Android.App;
using Android.OS;

namespace RecyclerViewSession
{
	// You don't have to do anything special for a basic list
	[Activity(Label = "RecyclerViewSession", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Title = "Basic Layout";
		}
	}
}


