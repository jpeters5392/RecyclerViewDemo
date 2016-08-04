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
	public class BasicAdapter : RecyclerView.Adapter
	{
		IList<DemoModel> items;
		RecyclerView recyclerView;

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

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var item = Items[position];

			var vh = (BasicViewHolder)holder;

			vh.BasicLayoutText.Text = item.Name;
			Picasso.With(recyclerView.Context).Load(item.ImageUrl).Into(vh.BasicLayoutImage);
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From(parent.Context).Inflate(LayoutId, parent, false);
			return CreateViewHolder(v);
		}

		protected virtual RecyclerView.ViewHolder CreateViewHolder(View v)
		{
			return new BasicViewHolder(v);
		}

		public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
		{
			base.OnAttachedToRecyclerView(recyclerView);
			this.recyclerView = recyclerView;
		}

		public override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
		{
			base.OnDetachedFromRecyclerView(recyclerView);
			this.recyclerView = null;
		}

		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			((BasicViewHolder)holder).DemoChanged += SwitchActivity;
			base.OnViewAttachedToWindow(holder);
		}

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

