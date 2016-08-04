using System;
using RecyclerViewSession.Events;

namespace RecyclerViewSession.TouchHelpers
{
	/// <summary>
	/// A simple interface to define some items that will be used by the touch helper
	/// </summary>
	public interface ISwipeable
	{
		/// <summary>
		/// I am not doing anything with this in this demo, 
		/// but you could use this to have some items in your RecyclerView be swipeable when others are not
		/// </summary>
		/// <value><c>true</c> if can swipe; otherwise, <c>false</c>.</value>
		bool CanSwipe { get; }

		/// <summary>
		/// An event to bubble up when an item is swiped.
		/// </summary>
		event EventHandler<ViewHolderEventArgs> Swipe;

		/// <summary>
		/// Called by the ItemTouchHelper callback when the item is swiped
		/// </summary>
		void SwipeItem();
	}
}

