using System;
using Android.Views;
using RecyclerViewSession.Events;
using RecyclerViewSession.TouchHelpers;

namespace RecyclerViewSession.ViewHolders
{
	public class SwipeableViewHolder : BasicViewHolder, ISwipeable
	{
		public SwipeableViewHolder(View v) : base(v)
		{
		}

		public bool CanSwipe
		{
			get
			{
				return true;
			}
		}

		public event EventHandler<ViewHolderEventArgs> Swipe;

		public void SwipeItem()
		{
			Swipe?.Invoke(this, new ViewHolderEventArgs(AdapterPosition));
		}
	}
}

