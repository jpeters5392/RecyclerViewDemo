using System;
using Android.Views;
using RecyclerViewSession.Events;
using RecyclerViewSession.TouchHelpers;

namespace RecyclerViewSession.ViewHolders
{
	/// <summary>
	/// A view holder that allows for an item to be swiped
	/// </summary>
	public class SwipeableViewHolder : BasicViewHolder, ISwipeable
	{
		public SwipeableViewHolder(View v) : base(v)
		{
		}

		/// <summary>
		/// I am not doing anything with this in this demo, 
		/// but you could use this to have some items in your RecyclerView be swipeable when others are not
		/// </summary>
		/// <value><c>true</c> if can swipe; otherwise, <c>false</c>.</value>
		public bool CanSwipe
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// An event to bubble up when an item is swiped.
		/// </summary>
		public event EventHandler<ViewHolderEventArgs> Swipe;

		/// <summary>
		/// Called by the ItemTouchHelper callback when the item is swiped
		/// </summary>
		public void SwipeItem()
		{
			Swipe?.Invoke(this, new ViewHolderEventArgs(AdapterPosition));
		}
	}
}

