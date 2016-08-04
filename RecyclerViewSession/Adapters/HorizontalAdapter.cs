using System;
namespace RecyclerViewSession.Adapters
{
	/// <summary>
	/// The adapter does not do anything different for horizontal display, unless
	/// you want a specific layout that is optimized for horizontal display.
	/// </summary>
	public class HorizontalAdapter : BasicAdapter
	{
		public override int LayoutId
		{
			get
			{
				return Resource.Layout.HorizontalLayout;
			}
		}
	}
}

