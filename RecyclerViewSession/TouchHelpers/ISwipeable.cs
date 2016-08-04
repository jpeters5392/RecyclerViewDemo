using System;
using RecyclerViewSession.Events;

namespace RecyclerViewSession.TouchHelpers
{
	public interface ISwipeable
	{
		bool CanSwipe { get; }
		event EventHandler<ViewHolderEventArgs> Swipe;
		void SwipeItem();
	}
}

