using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace RecyclerViewSession.Adapters
{
	/// <summary>
	/// There is nothing in the adapter specific to cards, other than 
	/// inflating a view that uses the card_view
	/// </summary>
	public class CardAdapter : BasicAdapter
	{
		public override int LayoutId
		{
			get
			{
				return Resource.Layout.BasicCardLayout;
			}
		}
	}
}

