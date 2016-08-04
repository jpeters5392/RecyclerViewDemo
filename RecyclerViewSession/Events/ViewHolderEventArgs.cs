using System;
namespace RecyclerViewSession.Events
{
	public class ViewHolderEventArgs : EventArgs
	{
		public int AdapterPosition { get; private set; }

		public ViewHolderEventArgs(int adapterPosition)
		{
			AdapterPosition = adapterPosition;
		}
	}
}

