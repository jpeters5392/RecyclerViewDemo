using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace RecyclerViewSession.Adapters
{
	public class SwipeAdapter : BasicAdapter
	{
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			base.OnBindViewHolder(holder, position);

			// TODO: Implement swipe behavior
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			return base.OnCreateViewHolder(parent, viewType);
		}
	}
}

