package ObjectClass;

import java.io.Serializable;

public class Shop implements Serializable {
	private int Shop_CD;
	private String CodeShop;
    private String NameShop;
    private String Street;
    private String Shop_SM;
    private String Shop_VT;
    private String Shop_POSM;
    private String Shop_DS;
    private String Shop_Street_VI;
    public String getShop_Street_VI() {
		return Shop_Street_VI;
	}
	public void setShop_Street_VI(String shop_Street_VI) {
		Shop_Street_VI = shop_Street_VI;
	}
	public int getShop_CD() {
		return Shop_CD;
	}
	public void setShop_CD(int shop_CD) {
		Shop_CD = shop_CD;
	}
	public String getCodeShop() {
		return CodeShop;
	}
	public void setCodeShop(String codeShop) {
		CodeShop = codeShop;
	}
	public String getNameShop() {
		return NameShop;
	}
	public void setNameShop(String nameShop) {
		NameShop = nameShop;
	}
	public String getStreet() {
		return Street;
	}
	public void setStreet(String street) {
		Street = street;
	}
	public String getShop_SM() {
		return Shop_SM;
	}
	public void setShop_SM(String shop_SM) {
		Shop_SM = shop_SM;
	}
	public String getShop_VT() {
		return Shop_VT;
	}
	public void setShop_VT(String shop_VT) {
		Shop_VT = shop_VT;
	}
	public String getShop_POSM() {
		return Shop_POSM;
	}
	public void setShop_POSM(String shop_POSM) {
		Shop_POSM = shop_POSM;
	}
	public String getShop_DS() {
		return Shop_DS;
	}
	public void setShop_DS(String shop_DS) {
		Shop_DS = shop_DS;
	}

}
