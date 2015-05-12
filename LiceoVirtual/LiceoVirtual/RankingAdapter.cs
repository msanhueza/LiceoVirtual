using LiceoVirtual;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.App;

public class RankingAdapter : BaseAdapter<RankingItem> {
	List<RankingItem> items;
	Activity context;
	public RankingAdapter(Activity context, List<RankingItem> items)
		: base()
	{
		this.context = context;
		this.items = items;
	}
	public override long GetItemId(int position)
	{
		return position;
	}
	public override RankingItem this[int position]
	{
		get { return items[position]; }
	}
	public override int Count
	{
		get { return items.Count; }
	}
	public override View GetView(int position, View convertView, ViewGroup parent)
	{
		var item = items[position];
		View view = convertView;
		if (view == null) // no view to re-use, create new
			view = context.LayoutInflater.Inflate(Resource.Layout.RankingPersonalizado, null);
		view.FindViewById<TextView>(Resource.Id.tvNombreRanking).Text = item.nombre;
		view.FindViewById<TextView>(Resource.Id.tvPuntajeRanking).Text = item.puntaje;
		return view;
	}
}

