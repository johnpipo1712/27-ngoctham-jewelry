package com.example.pda_pss;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

import ObjectClass.Maket_Visit;
import ObjectClass.MyAdapterListShop;
import ObjectClass.MySQLiteHelper;
import ObjectClass.Shop;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.provider.MediaStore.Images;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends Activity {

    MyAdapterListShop myAdapterShop;
    ListView lvShop;
    @Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		//Remove title bar
	    this.requestWindowFeature(Window.FEATURE_NO_TITLE);

	    //Remove notification bar
	    this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
	    setContentView(R.layout.activity_main);
		
	    EditText EditTextSearch = (EditText)findViewById(R.id.EditTxtSearch);
	    EditTextSearch.addTextChangedListener(new android.text.TextWatcher() {
			
			@Override
			public void onTextChanged(CharSequence s, int start, int before, int count) {
				// TODO Auto-generated method stub
				LoadSearch();
			}
			
			@Override
			public void beforeTextChanged(CharSequence s, int start, int count,
					int after) {
				// TODO Auto-generated method stub
				
			}
			
			@Override
			public void afterTextChanged(android.text.Editable s) {
				// TODO Auto-generated method stub
				
			}
		});
	    LoadDataShop();
	   
		
	}
	
	
    public void LoadDataShop()
    {
	   	 MySQLiteHelper db = new MySQLiteHelper(this);
	    
	    ArrayList<Shop> listShop = db.getAllShops();
	    if(listShop.size() > 0)
	    {
	    	myAdapterShop = new MyAdapterListShop(this,R.layout.item_list, listShop);
	    
		    lvShop = (ListView)findViewById(R.id.lvitem);
		    lvShop.setAdapter(myAdapterShop);
	    }
    }
 
    public void LoadSearch()
    {
    	EditText EditTextSearch = (EditText)findViewById(R.id.EditTxtSearch);
     	MySQLiteHelper db = new MySQLiteHelper(this);
 	    
 	    ArrayList<Shop> listShop = db.getAllShopsSearch(EditTextSearch.getText().toString());
 	   
    	myAdapterShop = new MyAdapterListShop(this,R.layout.item_list, listShop);
    
	    lvShop = (ListView)findViewById(R.id.lvitem);
	    lvShop.setAdapter(myAdapterShop);
 	    
 	    
    	
    }
    public void DisplayItem(View v)
    {
    	ListView  lvShop = (ListView)findViewById(R.id.lvitem);
    	int position = lvShop.getPositionForView(v);
    	Shop shop = (Shop)lvShop.getItemAtPosition(position);
		Intent i = new Intent(MainActivity.this,Layout_dialog_table.class);
	    Bundle bundle= new Bundle();
	    bundle.putSerializable("sendShop_CD", shop);
	    i.putExtra("infopacket", bundle);
	    startActivity(i);
    }
   
	    
}
