using System;
using Android.Support.V7.Widget;
using Android.Views;
using RecyclerViewSession.Events;
using RecyclerViewSession.ViewHolders;

namespace RecyclerViewSession.Adapters
{
	/// <summary>
	/// The swipeable adapter just registers a Swipe event handler for the event 
	/// that is bubbled up from the view holder
	/// </summary>
	public class SwipeableCardAdapter : CardAdapter
	{
		protected void OnItemSwiped(object sender, ViewHolderEventArgs e)
		{
			// delete the item from the list
			Items.RemoveAt(e.AdapterPosition);
			// notify the adapter to update the RecyclerView UI
			NotifyItemRemoved(e.AdapterPosition);
		}

		/// <summary>
		/// Register the event handler when the actual view is attached to the window
		/// </summary>
		/// <param name="holder">Holder.</param>
		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			((SwipeableViewHolder)holder).Swipe += OnItemSwiped;
			base.OnViewAttachedToWindow(holder);
		}

		/// <summary>
		/// Unregister the event handler when the actual view is detached from the window
		/// </summary>
		/// <param name="holder">Holder.</param>
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

