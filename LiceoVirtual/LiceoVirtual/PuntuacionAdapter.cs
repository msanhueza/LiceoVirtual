using LiceoVirtual;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.App;

public class PuntuacionAdapter : BaseAdapter<PuntuacionItem> {
	List<PuntuacionItem> items;
	Activity context;
	public PuntuacionAdapter(Activity context, List<PuntuacionItem> items)
		: base()
	{
		this.context = context;
		this.items = items;
	}
	public override long GetItemId(int position)
	{
		return position;
	}
	public override PuntuacionItem this[int position]
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
			view = context.LayoutInflater.Inflate(Resource.Layout.PuntuacionPersonalizado, null);
		view.FindViewById<TextView>(Resource.Id.tvFecha).Text = item.fecha;
		view.FindViewById<TextView>(Resource.Id.tvPuntaje).Text = item.puntaje;
		return view;
	}
}

