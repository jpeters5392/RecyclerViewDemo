using System;
using Android.Support.V7.Widget;
using Android.Views;
using RecyclerViewSession.Events;
using RecyclerViewSession.ViewHolders;

namespace RecyclerViewSession.Adapters
{
	public class SwipeableCardAdapter : CardAdapter
	{
		protected void OnItemSwiped(object sender, ViewHolderEventArgs e)
		{
			// delete the item
			Items.RemoveAt(e.AdapterPosition);
			NotifyItemRemoved(e.AdapterPosition);
		}

		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			((SwipeableViewHolder)holder).Swipe += OnItemSwiped;
			base.OnViewAttachedToWindow(holder);
		}

		public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			((SwipeableViewHolder)holder).Swipe -= OnItemSwiped;
			base.OnViewDetachedFromWindow(holder);
		}

		protected override RecyclerView.ViewHolder CreateViewHolder(View v)
		{
			return new SwipeableViewHolder(v);
		}
	}
}

