package ObjectClass;

import java.util.ArrayList;

import com.example.pda_pss.R;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class MyAdapterListShop  extends ArrayAdapter<Shop>{

	private Context context;
	private int textViewResourceId;
	private ArrayList<Shop> listShop;

	public MyAdapterListShop(Context context, int textViewResourceId,
			ArrayList<Shop> listShop) {
		super(context, textViewResourceId,listShop);
		this.context = context;
		this.textViewResourceId = textViewResourceId;
		this.listShop = listShop;
		
	}
	@Override
	public View getView(int position,View convertView,ViewGroup parrent)
	{
	     View v = convertView;
		if(v==null)
		{
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			v = inflater.inflate(textViewResourceId, null);
		}
		
		Shop shop = listShop.get(position);
		
		if(shop != null)
		{
		   
		   TextView txtName = (TextView)v.findViewById(R.id.txtVnamecusitem);
		   txtName.setText(shop.getNameShop()+"");
		   TextView txtCode = (TextView)v.findViewById(R.id.txtVcodecusitem);
		   txtCode.setText(shop.getCodeShop()+"");
		   TextView txtQuantity = (TextView)v.findViewById(R.id.txtVstreetitem);
		   txtQuantity.setText(shop.getStreet()+"");
		 /*  Spinner sp = (Spinner)v.findViewById(R.id.spinner1);
		   
		    ArrayAdapter<String> itemcombox = new ArrayAdapter<String>(context, android.R.layout.simple_spinner_item,ListSpr);
		    itemcombox.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		   sp.setAdapter(itemcombox);
		  */

		}
		return v;
		
	}
	
}


