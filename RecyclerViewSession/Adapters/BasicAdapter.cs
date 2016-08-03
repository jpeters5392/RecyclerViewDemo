using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
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
			View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.BasicLayout, parent, false);
			var vh = new BasicViewHolder(v);
			return vh;
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
	}
}

