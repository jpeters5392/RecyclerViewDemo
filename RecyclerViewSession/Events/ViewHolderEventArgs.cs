using System;
namespace RecyclerViewSession.Events
{
	/// <summary>
	/// A simple event args class that contains the position in the list of items
	/// </summary>
	public class ViewHolderEventArgs : EventArgs
	{
		public int AdapterPosition { get; private set; }

		public ViewHolderEventArgs(int adapterPosition)
		{
			AdapterPosition = adapterPosition;
		}
	}
}

