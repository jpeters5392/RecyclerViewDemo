using Android.App;
using Android.OS;

namespace RecyclerViewSession
{
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


