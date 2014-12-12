package ObjectClass;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;
import android.webkit.WebChromeClient.CustomViewCallback;

public class MySQLiteHelper extends SQLiteOpenHelper {
	 
    // Database Version
    private static final int DATABASE_VERSION = 1;
    // Database Name
    private static final String DATABASE_NAME = "PSSDB";

 
    public MySQLiteHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);  
    }
 
    @Override
    public void onCreate(SQLiteDatabase db) {
        // SQL statement to create  table
        String CREATE_SHOP_TABLE = "CREATE TABLE M_SHOP ( " +
                "SHOP_CD INTEGER PRIMARY KEY AUTOINCREMENT, " + 
                "SHOP_CODE TEXT, "+
                "SHOP_NAME TEXT, "+
                "SHOP_STREET TEXT,"+
                "SHOP_SM TEXT,"+
                "SHOP_VT TEXT,"+
                "SHOP_POSM TEXT,"+
                "SHOP_DS TEXT,"+  
                "SHOP_STREET_VI TEXT"+  
                " )";
        String CREATE_Maket_Visit_TABLE = "CREATE TABLE O_MAKET_VISIT ( " +
                "MAKET_VISIT_CD INTEGER PRIMARY KEY AUTOINCREMENT, " + 
                "SHOP_CD INTEGER, "+
                "NOTE_POSM TEXT, "+
                "NOTE_VTTB TEXT, "+
                "NOTE_SMTB TEXT, "+
                "NOTE_DS TEXT, "+
                "NOTE_CHPP TEXT, "+
                "NOTE_CHMHHT TEXT," + 
                "ISTRUE_POSM INTEGER, "+
                "ISTRUE_VTTB INTEGER, "+
                "ISTRUE_SMTB INTEGER, "+
                "ISTRUE_CHPP INTEGER, "+
                "STATUS_POSM TEXT,"+
                "NOTE_DGT TEXT, "+
                "URL_IMAGE TEXT )";
        // create  table
        db.execSQL(CREATE_SHOP_TABLE);
        db.execSQL(CREATE_Maket_Visit_TABLE);
    }
 
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Drop older books table if existed
        db.execSQL("DROP TABLE IF EXISTS M_SHOP");
        db.execSQL("DROP TABLE IF EXISTS O_MAKET_VISIT");
        // create fresh books table
        this.onCreate(db);
   
        
    }
    // Books table name
    private static final String TABLE_M_SHOP = "M_SHOP";
    private static final String TABLE_MAKET_VISIT = "O_MAKET_VISIT";
    // Books Table Columns names
    private static final String KEY_SHOP_CD = "SHOP_CD";
    private static final String KEY_SHOP_CODE = "SHOP_CODE";
    private static final String KEY_SHOP_NAME = "SHOP_NAME";
    private static final String KEY_SHOP_STREET = "SHOP_STREET";
    private static final String KEY_SHOP_SM = "SHOP_SM";
    private static final String KEY_SHOP_VT = "SHOP_VT";
    private static final String KEY_SHOP_POSM = "SHOP_POSM";
    private static final String KEY_SHOP_DS = "SHOP_DS";
    private static final String KEY_SHOP_STREET_VI = "SHOP_STREET_VI";
    private static final String[] COLUMNS_M_SHOP =
    	{KEY_SHOP_CD
    	,KEY_SHOP_CODE
    	,KEY_SHOP_NAME
    	,KEY_SHOP_STREET
    	,KEY_SHOP_SM
    	,KEY_SHOP_VT
    	,KEY_SHOP_POSM
    	,KEY_SHOP_DS
    	,KEY_SHOP_STREET_VI};
    
    
   
    private static final String KEY_MAKET_VISIT_CD = "MAKET_VISIT_CD";
    private static final String KEY_SHOP_MAKET_CD = "SHOP_CD";
    private static final String KEY_NOTE_POSM = "NOTE_POSM";
    private static final String KEY_NOTE_SMTB = "NOTE_SMTB";
    private static final String KEY_NOTE_VTTB = "NOTE_VTTB";
    private static final String KEY_NOTE_DS = "NOTE_DS";
    private static final String KEY_NOTE_CHPP = "NOTE_CHPP";
    private static final String KEY_NOTE_CHMHHT = "NOTE_CHMHHT";
    private static final String KEY_ISTRUE_POSM = "ISTRUE_POSM";
    private static final String KEY_ISTRUE_VTTB = "ISTRUE_VTTB";
    private static final String KEY_ISTRUE_SMTB = "ISTRUE_SMTB";
    private static final String KEY_ISTRUE_CHPP = "ISTRUE_CHPP";
    private static final String KEY_STATUS_POSM = "STATUS_POSM";
    private static final String KEY_NOTE_DGT = "NOTE_DGT";
    private static final String KEY_URL_IMAGE = "URL_IMAGE";
    private static final String[] COLUMNS_O_MAKET_VISIT = 
    	         {KEY_MAKET_VISIT_CD
    	         ,KEY_SHOP_MAKET_CD
    	         ,KEY_NOTE_POSM
    	         ,KEY_NOTE_SMTB
    	         ,KEY_NOTE_VTTB
    	         ,KEY_NOTE_DS
    	         ,KEY_NOTE_CHPP
    	         ,KEY_NOTE_CHMHHT
    	         ,KEY_ISTRUE_POSM
    	         ,KEY_ISTRUE_VTTB
    	         ,KEY_ISTRUE_SMTB
    	         ,KEY_ISTRUE_CHPP
    	         ,KEY_STATUS_POSM
    	         ,KEY_NOTE_DGT
    	         ,KEY_URL_IMAGE};
    
    
    public void addMaketVisit(Maket_Visit mk_vs){
        Log.d("addMaketVisit", mk_vs.toString());
        // 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
 
        // 2. create ContentValues to add key "column"/value
        ContentValues values = new ContentValues();
        values.put(KEY_SHOP_MAKET_CD, mk_vs.getShop_CD()); 
        values.put(KEY_NOTE_POSM, mk_vs.getNotePOSM()); 
        values.put(KEY_NOTE_SMTB, mk_vs.getNoteSMTB()); 
        values.put(KEY_NOTE_VTTB, mk_vs.getNoteVTTB()); 
        values.put(KEY_NOTE_DS, mk_vs.getNoteDS()); 
        values.put(KEY_NOTE_CHPP, mk_vs.getNoteCHCPP()); 
        values.put(KEY_NOTE_CHMHHT, mk_vs.getNoteCHMHHT()); 
        values.put(KEY_ISTRUE_POSM, mk_vs.getIsTruePOSM()); 
        values.put(KEY_ISTRUE_VTTB, mk_vs.getIsTrueVTTB()); 
        values.put(KEY_ISTRUE_SMTB, mk_vs.getIsTrueSMTB()); 
        values.put(KEY_ISTRUE_CHPP, mk_vs.getIsTrueCHCPP());
        values.put(KEY_STATUS_POSM, mk_vs.getStatusPOSM());
        values.put(KEY_NOTE_DGT, mk_vs.getNoteDGT());
        values.put(KEY_URL_IMAGE, mk_vs.getUrlImage());
        
        // 3. insert
        db.insert(TABLE_MAKET_VISIT, // table
                null, //nullColumnHack
                values); // key/value -> keys = column names/ values = column values
 
        // 4. close
        db.close(); 
    }
 
    public int updateMaketVisit(Maket_Visit mk_vs) {
    	 Log.d("updateMaketVisit", mk_vs.toString());
        // 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
 
        // 2. create ContentValues to add key "column"/value
        ContentValues values = new ContentValues();
        values.put(KEY_NOTE_POSM, mk_vs.getNotePOSM()); 
        values.put(KEY_NOTE_SMTB, mk_vs.getNoteSMTB()); 
        values.put(KEY_NOTE_VTTB, mk_vs.getNoteVTTB()); 
        values.put(KEY_NOTE_DS, mk_vs.getNoteDS()); 
        values.put(KEY_NOTE_CHPP, mk_vs.getNoteCHCPP()); 
        values.put(KEY_NOTE_CHMHHT, mk_vs.getNoteCHMHHT()); 
        values.put(KEY_ISTRUE_POSM, mk_vs.getIsTruePOSM()); 
        values.put(KEY_ISTRUE_VTTB, mk_vs.getIsTrueVTTB()); 
        values.put(KEY_ISTRUE_SMTB, mk_vs.getIsTrueSMTB()); 
        values.put(KEY_ISTRUE_CHPP, mk_vs.getIsTrueCHCPP());
        values.put(KEY_STATUS_POSM, mk_vs.getStatusPOSM());
        values.put(KEY_NOTE_DGT, mk_vs.getNoteDGT());
        values.put(KEY_URL_IMAGE, mk_vs.getUrlImage());
        // 3. updating row
        int i = db.update(TABLE_MAKET_VISIT, //table
                values, // column/value
                KEY_SHOP_MAKET_CD+" = ?", // selections
                new String[] { String.valueOf(mk_vs.getShop_CD()) }); //selection args
 
        // 4. close
        db.close();
 
        return i;
 
    }
 
    
    public Maket_Visit getMaket_Visit(int SHOP_CD){
 
    	 String query = "SELECT  * FROM " + TABLE_MAKET_VISIT + " WHERE SHOP_CD = " + SHOP_CD;
        // 1. get reference to readable DB
    	   SQLiteDatabase db = this.getWritableDatabase();
           Cursor cursor = db.rawQuery(query, null);
    
      /*  // 2. build query
        Cursor cursor = 
                db.query(TABLE_MAKET_VISIT, // a. table
                COLUMNS_O_MAKET_VISIT, // b. column names
                " SHOP_CD = ?", // c. selections 
                new String[] { String.valueOf(SHOP_CD) }, // d. selections args
                null, // e. group by
                null, // f. having
                null, // g. order by
                null); // h. limit
       */
        // 3. if we got results get the first one
        Maket_Visit maketvisit = new Maket_Visit();
        if (cursor != null)
        {
        	   if(cursor.getCount() > 0)
        	   {
	                    cursor.moveToFirst();
				        // 4. build book object
				        maketvisit.setMaket_Visit_CD(Integer.parseInt(cursor.getString(0)));
				        maketvisit.setShop_CD(Integer.parseInt(cursor.getString(1)));
				        maketvisit.setNotePOSM(cursor.getString(2));
				        maketvisit.setNoteSMTB(cursor.getString(3));
				        maketvisit.setNoteVTTB(cursor.getString(4));
				        maketvisit.setNoteDS(cursor.getString(5));
				        maketvisit.setNoteCHCPP(cursor.getString(6));
				        maketvisit.setNoteCHMHHT(cursor.getString(7));
				        maketvisit.setIsTruePOSM(Integer.parseInt(cursor.getString(8)));
				        maketvisit.setIsTrueVTTB(Integer.parseInt(cursor.getString(9)));
				        maketvisit.setIsTrueSMTB(Integer.parseInt(cursor.getString(10)));
				        maketvisit.setIsTrueCHCPP(Integer.parseInt(cursor.getString(11)));
				        maketvisit.setStatusPOSM(cursor.getString(12));
				        maketvisit.setNoteDGT(cursor.getString(13));
				        maketvisit.setUrlImage(cursor.getString(14));
				        Log.d("getMaket_Visit("+SHOP_CD+")", maketvisit.toString());
		            
	            }
        	   else
               {
               	maketvisit.setShop_CD(-1);	
               	Log.d("getMaket_Visit("+SHOP_CD+")", maketvisit.toString());
               }

	        }
        	
        
        
        // 3. close
        db.close();
        
        // 5. return book
        return maketvisit;
    }
    public void deleteMaketVisit(Maket_Visit mk_vs)
    {
    	  // 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
 
        // 2. delete
        db.delete(TABLE_MAKET_VISIT,
                KEY_SHOP_CD+" = ?",
                new String[] { String.valueOf(mk_vs.getShop_CD()) });
 
        // 3. close
        db.close();
 
        Log.d("deleteMaketVisit", mk_vs.toString());
    }
    // Get All Shops
    public ArrayList<Shop> getAllShops() {
        ArrayList<Shop> shops = new ArrayList<Shop>();
 
        // 1. build the query
        String query = "SELECT  * FROM " + TABLE_M_SHOP;
 
        // 2. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(query, null);
 
        // 3. go over each row, build book and add it to list
        Shop shop = null;
        if(cursor.getCount() > 0)
        {
	        if (cursor.moveToFirst()) {
	            do {
	                shop = new Shop();
	            	shop.setShop_CD(Integer.parseInt(cursor.getString(0)));
	            	shop.setCodeShop(cursor.getString(1));
	            	shop.setNameShop(cursor.getString(2));
	                shop.setStreet(cursor.getString(3));
	                shop.setShop_SM(cursor.getString(4));
	                shop.setShop_VT(cursor.getString(5));
	                shop.setShop_POSM(cursor.getString(6));
	                shop.setShop_DS(cursor.getString(7));
	                shop.setShop_Street_VI(cursor.getString(8));
	                // Add book to books
	            	shops.add(shop);
	            } while (cursor.moveToNext());
	        }
	 
	        Log.d("getAllShops()", shop.toString());
        }

        // 3. close
        db.close();
        // return books
        return shops;
    }
    public void addShop(Shop shop){
        Log.d("addShop", shop.toString());
        // 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
 
        // 2. create ContentValues to add key "column"/value
        ContentValues values = new ContentValues();
        values.put(KEY_SHOP_CODE, shop.getCodeShop()); 
        values.put(KEY_SHOP_NAME, shop.getNameShop()); 
        values.put(KEY_SHOP_STREET, shop.getStreet()); 
        values.put(KEY_SHOP_SM, shop.getShop_SM()); 
        values.put(KEY_SHOP_VT, shop.getShop_VT()); 
        values.put(KEY_SHOP_POSM, shop.getShop_POSM()); 
        values.put(KEY_SHOP_DS, shop.getShop_DS()); 
        values.put(KEY_SHOP_STREET_VI, shop.getShop_Street_VI()); 
        // 3. insert
        db.insert(TABLE_M_SHOP, // table
                null, //nullColumnHack
                values); // key/value -> keys = column names/ values = column values
 
        // 4. close
        db.close(); 
    }
    public ArrayList<Shop> getAllShopsSearch(String Street) {
        ArrayList<Shop> shops = new ArrayList<Shop>();
 
        // 1. build the query
        String query = "SELECT  * FROM " + TABLE_M_SHOP + " WHERE SHOP_STREET like '%"+Street+"%'";
 
        // 2. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(query, null);
 
        // 3. go over each row, build book and add it to list
        Shop shop = null;
        if (cursor.moveToFirst()) {
            do {
                shop = new Shop();
            	shop.setShop_CD(Integer.parseInt(cursor.getString(0)));
            	shop.setCodeShop(cursor.getString(1));
            	shop.setNameShop(cursor.getString(2));
                shop.setStreet(cursor.getString(3));
                shop.setShop_SM(cursor.getString(4));
                shop.setShop_VT(cursor.getString(5));
                shop.setShop_POSM(cursor.getString(6));
                shop.setShop_DS(cursor.getString(7));
                shop.setShop_Street_VI(cursor.getString(8));
                // Add book to books
            	shops.add(shop);
            } while (cursor.moveToNext());
        }
 
        Log.d("getAllShopsSearch()", shop.toString());
 
        // return books
        return shops;
    }
    // Updating single book

  /*  // Deleting single book
    public void deleteBook(Book book) {
 
        // 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
 
        // 2. delete
        db.delete(TABLE_BOOKS,
                KEY_ID+" = ?",
                new String[] { String.valueOf(book.getId()) });
 
        // 3. close
        db.close();
 
        Log.d("deleteBook", book.toString());
 
    }
    public void deleteAllBook()
    {
    	// 1. get reference to writable DB
        SQLiteDatabase db = this.getWritableDatabase();
        
        db.execSQL("Delete From " + TABLE_BOOKS);
    } */
    
}