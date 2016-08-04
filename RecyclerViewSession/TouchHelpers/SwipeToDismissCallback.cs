﻿using System;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;

namespace RecyclerViewSession.TouchHelpers
{
	public class SwipeToDismissCallback : ItemTouchHelper.Callback
	{
		public override bool IsItemViewSwipeEnabled
		{
			get
			{
				return true;
			}
		}

		public override bool IsLongPressDragEnabled
		{
			get
			{
				return false;
			}
		}

		public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
		{
			return false;
		}

		public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
		{
			var swipableViewHolder = viewHolder as ISwipeable;

			// only allow the swipe if the current item supports it
			if (swipableViewHolder != null && swipableViewHolder.CanSwipe)
			{
				// only let them swipe left and right, not up and down
				int dragFlags = 0;
				int swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
				return MakeMovementFlags(dragFlags, swipeFlags);
			}

			// don't allow the swipe
			return MakeMovementFlags(0, 0);
		}

		public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
		{
			var swipableViewHolder = viewHolder as ISwipeable;
			if (swipableViewHolder != null)
			{
				// if we are swiped off to the right or left then let the viewholder know that it was swiped
				if (direction == ItemTouchHelper.End || direction == ItemTouchHelper.Start)
				{
					swipableViewHolder.SwipeItem();
				}
			}
		}
	}
}

