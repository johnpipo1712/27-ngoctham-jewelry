package com.example.pda_pss;

import java.util.ArrayList;

import ObjectClass.Maket_Visit;
import ObjectClass.MyAdapterListShop;
import ObjectClass.MySQLiteHelper;
import ObjectClass.Shop;
import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends Activity {

    MyAdapterListShop myAdapterShop;
    ListView lvShop;
    int Shop_CD;
    String [] ListSpr = {"Đúng","Sai"};
    String [] ListSprStatus = {"10%","20%","30%","40%","50%","60%","70%","80%","90%","100%"};
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		LinearLayout PanelThem = (LinearLayout)findViewById(R.id.PanelThem);
		PanelThem.setVisibility(View.INVISIBLE);

	    LoadDataShop();
	    LoadCombox();
		
	}
	public void LoadCombox()
	{
		Spinner spinnerSMTB = (Spinner)findViewById(R.id.spinnerSMTB);
	    ArrayAdapter<String> itemcomboxSMTB = new ArrayAdapter<String>(this, R.layout.item_combox,ListSpr);
	    itemcomboxSMTB.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	    spinnerSMTB.setAdapter(itemcomboxSMTB);
	    Spinner spinnerVTTB = (Spinner)findViewById(R.id.spinnerVTTB);
	    ArrayAdapter<String> itemcomboxVTTB = new ArrayAdapter<String>(this, R.layout.item_combox,ListSpr);
	    itemcomboxVTTB.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	    spinnerVTTB.setAdapter(itemcomboxVTTB);
	    Spinner spinnerPOSM = (Spinner)findViewById(R.id.spinnerPOSM);
	    ArrayAdapter<String> itemcomboxPOSM = new ArrayAdapter<String>(this, R.layout.item_combox,ListSpr);
	    itemcomboxPOSM.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	    spinnerPOSM.setAdapter(itemcomboxPOSM);
	    Spinner spinnerCPP = (Spinner)findViewById(R.id.spinnerCPP);
	    ArrayAdapter<String> itemcomboxCPP = new ArrayAdapter<String>(this, R.layout.item_combox,ListSpr);
	    itemcomboxCPP.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	    spinnerCPP.setAdapter(itemcomboxCPP);
	    Spinner spinnerSTATUSPOSM = (Spinner)findViewById(R.id.spinnerSTATUSPOSM);
	    ArrayAdapter<String> itemcomboxSTATUSPOSM = new ArrayAdapter<String>(this, R.layout.item_combox,ListSprStatus);
	    itemcomboxSTATUSPOSM.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	    spinnerSTATUSPOSM.setAdapter(itemcomboxSTATUSPOSM);
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
    public void Save(View v)
	{
    	
        TextView txtNotePOSM = (TextView)findViewById(R.id.txtVNotePOSM);
    	Spinner txtStatusPOSM = (Spinner)findViewById(R.id.spinnerSTATUSPOSM);
    	Spinner txtIsTruePOSM = (Spinner)findViewById(R.id.spinnerPOSM);
    	TextView txtNoteSMTB = (TextView)findViewById(R.id.txtVEditSM);
    	Spinner txtIsTrueSMTB = (Spinner)findViewById(R.id.spinnerSMTB);
    	TextView txtNoteVTTB = (TextView)findViewById(R.id.txtVEditVT);
    	Spinner txtIsTrueVTTB = (Spinner)findViewById(R.id.spinnerVTTB);
    	TextView txtNoteDS = (TextView)findViewById(R.id.txtVNoteDS);
    	TextView txtNoteCHMHHT = (TextView)findViewById(R.id.txtVEditCHMHT);
    	TextView txtNoteCHCPP = (TextView)findViewById(R.id.txtVEditCHPP);
    	Spinner txtIsTrueCHCPP = (Spinner)findViewById(R.id.spinnerCPP);
    	TextView txtVDGT = (TextView)findViewById(R.id.txtVTexDGT);
    	String Url_Image = "";

    	Maket_Visit mk_vs = new Maket_Visit();
    	mk_vs.setShop_CD(Shop_CD);
    	mk_vs.setNotePOSM(txtNotePOSM.getText()+" ");
    	mk_vs.setNoteSMTB(txtNoteSMTB.getText()+" ");
    	mk_vs.setNoteVTTB(txtNoteVTTB.getText()+" ");
    	mk_vs.setNoteCHCPP(txtNoteCHCPP.getText()+" ");
    	mk_vs.setNoteCHMHHT(txtNoteCHMHHT.getText()+" ");
    	mk_vs.setNoteDS(txtNoteDS.getText()+" ");
    	if(txtIsTrueCHCPP.getSelectedItem().toString() == "Đúng")
    	   mk_vs.setIsTrueCHCPP(1);
    	else
    	   mk_vs.setIsTrueCHCPP(0);
    	if(txtIsTruePOSM.getSelectedItem().toString() == "Đúng")
    	   mk_vs.setIsTruePOSM(1);
    	else
    	   mk_vs.setIsTruePOSM(0);
    	if(txtIsTrueVTTB.getSelectedItem().toString() == "Đúng")
       	   mk_vs.setIsTrueVTTB(1);
    	else
     	   mk_vs.setIsTrueVTTB(0);
    	if(txtIsTrueSMTB.getSelectedItem().toString() == "Đúng")
           mk_vs.setIsTrueSMTB(1);
    	else
     	   mk_vs.setIsTrueSMTB(0);
    	mk_vs.setStatusPOSM(txtStatusPOSM.getSelectedItem().toString());
    	mk_vs.setNoteDGT(txtVDGT.getText()+" ");
    	mk_vs.setUrlImage(Url_Image);
    	MySQLiteHelper db = new MySQLiteHelper(this);
    	db.deleteMaketVisit(mk_vs);
	    db.addMaketVisit(mk_vs);
    	Shop_CD = -1;
    	LinearLayout PanelThem = (LinearLayout)findViewById(R.id.PanelThem);
		PanelThem.setVisibility(View.INVISIBLE);
	}
    public void Exit(View v)
	{
    	
		LinearLayout PanelThem = (LinearLayout)findViewById(R.id.PanelThem);
		NullTxt();
		Shop_CD = -1;
		PanelThem.setVisibility(View.INVISIBLE);
	}
    public void NullTxt()
    {
        TextView txtNotePOSM = (TextView)findViewById(R.id.txtVNotePOSM);
    	Spinner txtStatusPOSM = (Spinner)findViewById(R.id.spinnerSTATUSPOSM);
    	Spinner txtIsTruePOSM = (Spinner)findViewById(R.id.spinnerPOSM);
    	TextView txtNoteSMTB = (TextView)findViewById(R.id.txtVEditSM);
    	Spinner txtIsTrueSMTB = (Spinner)findViewById(R.id.spinnerSMTB);
    	TextView txtNoteVTTB = (TextView)findViewById(R.id.txtVEditVT);
    	Spinner txtIsTrueVTTB = (Spinner)findViewById(R.id.spinnerVTTB);
    	TextView txtNoteDS = (TextView)findViewById(R.id.txtVNoteDS);
    	TextView txtNoteCHMHHT = (TextView)findViewById(R.id.txtVEditCHMHT);
    	TextView txtNoteCHCPP = (TextView)findViewById(R.id.txtVEditCHPP);
    	Spinner txtIsTrueCHCPP = (Spinner)findViewById(R.id.spinnerCPP);
    	TextView txtVDGT = (TextView)findViewById(R.id.txtVTexDGT);
    	txtNotePOSM.setText("");
    	txtNoteCHCPP.setText("");
    	txtNoteCHMHHT.setText("");
    	txtNoteDS.setText("");
    	txtNoteSMTB.setText("");
    	txtNoteVTTB.setText("");
    	txtVDGT.setText("");
    	
    	txtStatusPOSM.setSelection(0);
    	txtIsTrueCHCPP.setSelection(0);
    	txtIsTruePOSM.setSelection(0);
    	txtIsTrueSMTB.setSelection(0);
    	txtIsTrueVTTB.setSelection(0);
    	
    
    }
    public void DisplayItem(View v)
    {
    	NullTxt();	
    	int position = lvShop.getPositionForView(v);
    	Shop shop = (Shop)lvShop.getItemAtPosition(position);
    	Shop_CD = shop.getShop_CD();
    	TextView txtShop_Code = (TextView)findViewById(R.id.txtVShop_Code);
    	txtShop_Code.setText(shop.getCodeShop());
    	TextView txtShop_Name = (TextView)findViewById(R.id.txtVShop_Name);
    	txtShop_Name.setText(shop.getNameShop());
    	TextView txtShop_Street = (TextView)findViewById(R.id.txtVShop_Street);
    	txtShop_Street.setText(shop.getStreet());
    	TextView txtShop_SM = (TextView)findViewById(R.id.txtVTextSM);
    	txtShop_SM.setText("Số mặt " + shop.getShop_SM());
    	TextView txtShop_VT = (TextView)findViewById(R.id.txtVVT);
    	txtShop_VT.setText("Vị trí " + shop.getShop_VT());
    	TextView txtShop_POSM = (TextView)findViewById(R.id.txtVTextPOSM);
    	txtShop_POSM.setText(shop.getShop_POSM());
    	TextView txtShop_DS = (TextView)findViewById(R.id.txtVTextDS);
    	txtShop_DS.setText(shop.getShop_DS());
    	MySQLiteHelper db = new MySQLiteHelper(this);
    	Maket_Visit mk_vs = db.getMaket_Visit(Shop_CD);
    	if(mk_vs.getShop_CD() != -1)
    	{
    		TextView txtNotePOSM = (TextView)findViewById(R.id.txtVNotePOSM);
        	Spinner txtStatusPOSM = (Spinner)findViewById(R.id.spinnerSTATUSPOSM);
        	Spinner txtIsTruePOSM = (Spinner)findViewById(R.id.spinnerPOSM);
        	TextView txtNoteSMTB = (TextView)findViewById(R.id.txtVEditSM);
        	Spinner txtIsTrueSMTB = (Spinner)findViewById(R.id.spinnerSMTB);
        	TextView txtNoteVTTB = (TextView)findViewById(R.id.txtVEditVT);
        	Spinner txtIsTrueVTTB = (Spinner)findViewById(R.id.spinnerVTTB);
        	TextView txtNoteDS = (TextView)findViewById(R.id.txtVNoteDS);
        	TextView txtNoteCHMHHT = (TextView)findViewById(R.id.txtVEditCHMHT);
        	TextView txtNoteCHCPP = (TextView)findViewById(R.id.txtVEditCHPP);
        	Spinner txtIsTrueCHCPP = (Spinner)findViewById(R.id.spinnerCPP);
        	TextView txtVDGT = (TextView)findViewById(R.id.txtVTexDGT);
        	txtNotePOSM.setText(mk_vs.getNotePOSM());
        	txtNoteSMTB.setText(mk_vs.getNoteSMTB());
        	txtNoteVTTB.setText(mk_vs.getNoteVTTB());
        	txtNoteDS.setText(mk_vs.getNoteDS());
        	txtNoteCHMHHT.setText(mk_vs.getNoteCHMHHT());
        	txtNoteCHCPP.setText(mk_vs.getNoteCHCPP());
        	txtVDGT.setText(mk_vs.getNoteDGT());
        	txtStatusPOSM.setSelection(1);
        	ArrayAdapter myAdapStatus = (ArrayAdapter)txtStatusPOSM.getAdapter(); //cast to an ArrayAdapter
        	int spinnerPosition = myAdapStatus.getPosition(mk_vs.getStatusPOSM());
        	txtStatusPOSM.setSelection(spinnerPosition);
        	if(mk_vs.getIsTruePOSM() == 1)
        	{
        		txtIsTruePOSM.setSelection(0);
        	}
        	else
        	{
        		txtIsTruePOSM.setSelection(1);
        	}
        	if(mk_vs.getIsTrueSMTB() == 1)
        	{
        		txtIsTrueSMTB.setSelection(0);
        	}
        	else
        	{
        		txtIsTrueSMTB.setSelection(1);
        	}
        	if(mk_vs.getIsTrueVTTB() == 1)
        	{
        		txtIsTrueVTTB.setSelection(0);
        	}
        	else
        	{
        		txtIsTrueVTTB.setSelection(1);
        	}
        	if(mk_vs.getIsTrueCHCPP() == 1)
        	{
        		txtIsTrueCHCPP.setSelection(0);
        	}
        	else
        	{
        		txtIsTrueCHCPP.setSelection(1);
        	}
        	
    	}
    	
    	LinearLayout PanelThem = (LinearLayout)findViewById(R.id.PanelThem);
		PanelThem.setVisibility(View.VISIBLE);
    }
	
	    
}
