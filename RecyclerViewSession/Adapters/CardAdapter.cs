using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace RecyclerViewSession.Adapters
{
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

