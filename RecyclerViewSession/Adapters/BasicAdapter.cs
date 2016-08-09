using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using RecyclerViewSession.Events;
using RecyclerViewSession.Models;
using RecyclerViewSession.ViewHolders;
using Square.Picasso;

namespace RecyclerViewSession.Adapters
{
	/// <summary>
	/// This defines a basic adapter that creates a view holder, handles data updates, 
	/// and binds to the button event that is bubbled up from the view holder
	/// </summary>
	public class BasicAdapter : RecyclerView.Adapter
	{
		IList<DemoModel> items;
		protected RecyclerView recyclerView;

		public IList<DemoModel> Items
		{
			get
			{
				if (items == null)
				{
					items = new List<DemoModel>();
				}

				return items;
			}
			set
			{
				items = value;
				// if we replaced the list of items then 
				// notify the RecyclerView that it needs to update the UI
				NotifyDataSetChanged();
			}
		}

		public virtual int LayoutId 
		{ 
			get
			{
				return Resource.Layout.BasicLayout;
			}
		}

		public BasicAdapter()
		{
			Items = new List<DemoModel>();
		}

		public override int ItemCount
		{
			get
			{
				return Items.Count;
			}
		}

		/// <summary>
		/// This is called to bind an existing view holder to a data item
		/// </summary>
		/// <param name="holder">Holder.</param>
		/// <param name="position">Position.</param>
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var item = Items[position];

			var vh = (BasicViewHolder)holder;

			vh.BasicLayoutText.Text = item.Name;
			Picasso.With(recyclerView.Context).Load(item.ImageUrl).Into(vh.BasicLayoutImage);
		}

		/// <summary>
		/// This is called whenever a new view holder is needed
		/// </summary>
		/// <returns>The create view holder.</returns>
		/// <param name="parent">Parent.</param>
		/// <param name="viewType">View type.</param>
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From(parent.Context).Inflate(LayoutId, parent, false);
			return CreateViewHolder(v);
		}

		protected virtual RecyclerView.ViewHolder CreateViewHolder(View v)
		{
			return new BasicViewHolder(v);
		}

		/// <summary>
		/// Grab a reference to the RecyclerView when the adapter is attached to it
		/// </summary>
		/// <param name="recyclerView">Recycler view.</param>
		public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
		{
			base.OnAttachedToRecyclerView(recyclerView);
			this.recyclerView = recyclerView;
		}

		/// <summary>
		/// Clean up the reference to the RecyclerView when the adapter is removed from it
		/// </summary>
		/// <param name="recyclerView">Recycler view.</param>
		public override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
		{
			base.OnDetachedFromRecyclerView(recyclerView);
			this.recyclerView = null;
		}

		/// <summary>
		/// Register the event handler when the actual view is attached to the window
		/// </summary>
		/// <param name="holder">Holder.</param>
		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			((BasicViewHolder)holder).DemoChanged += SwitchActivity;
			base.OnViewAttachedToWindow(holder);
		}

		/// <summary>
		/// Unregister the event handler when the actual view is detached from the window
		/// </summary>
		/// <param name="holder">Holder.</param>
		public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			((BasicViewHolder)holder).DemoChanged -= SwitchActivity;
			base.OnViewDetachedFromWindow(holder);
		}

		public void SwitchActivity(object sender, ViewHolderEventArgs e)
		{
			var intent = new Intent(recyclerView.Context, Items[e.AdapterPosition].ActivityType);
			recyclerView.Context.StartActivity(intent);
		}
	}
}

