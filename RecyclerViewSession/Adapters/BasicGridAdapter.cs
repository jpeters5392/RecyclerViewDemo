using System;
namespace RecyclerViewSession.Adapters
{
	/// <summary>
	/// There is nothing in the adapter specific to Grids, other than 
	/// (optionally) inflating a view that is optimized for a Grid layout
	/// </summary>
	public class BasicGridAdapter : BasicAdapter
	{
		public override int LayoutId
		{
			get
			{
				return Resource.Layout.BasicGridLayout;
			}
		}
	}
}

