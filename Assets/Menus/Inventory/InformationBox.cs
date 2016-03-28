using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationBox : MonoBehaviour {

	public bool shopMode;

    GameObject equip;
	EquipScript equipS;
	GameObject eat;
	EatScript eatS;
	BuyScript buyS;
	GameObject buy;
    Text txt;
    string displayFormat = "Name: [name] \nDescription: [description]";
    string weaponFormat = "Damage: [damage] \nSpeed: [speed] \nRange: [range]";
	string shopFormat = "Cost: [cost]";
	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        equip = GameObject.Find("EquipButton");
		equipS = equip.GetComponent<EquipScript>();
		eat = GameObject.Find("EatButton");
		eatS = eat.GetComponent<EatScript>();
		if (shopMode) {
			buy = GameObject.Find("BuyButton");
			buyS = buy.GetComponent<BuyScript>();
			buy.SetActive(false);
		}
        equip.SetActive(false);
		eat.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Sets the information display to the correct text for the object passed
	/// </summary>
	/// <param name="obj"></param>
    public void DisplayObject(object obj) {
        string display = displayFormat;
        if (obj is IEquippable && !shopMode) {
			if (!equip.activeSelf) {
				equip.SetActive(true);
			}
			equipS.obj = obj;
		} else {
            if (equip.activeSelf)
                equip.SetActive(false);
        }
		if (obj is IFood && !shopMode) {
			if (!eat.activeSelf) {
				eat.SetActive(true);
			}
			eatS.obj = obj;
		} else {
			if (eat.activeSelf)
				eat.SetActive(false);
		}
		if (shopMode) {
			if (obj is Iitem) {
				buy.SetActive(true);
				buyS.obj = obj;
			} else {
				buy.SetActive(false);
			}
			eat.SetActive(false);
			equip.SetActive(false);
		}
        if (obj is IWeapon) {
            IWeapon weapon = (IWeapon)obj;
            string[] description = weapon.DisplayInformation();
            string displayWeapon = weaponFormat;
			string displayCost = shopFormat;
			displayCost = displayCost.Replace("[cost]", ((Iitem)obj).Cost.ToString());
            displayWeapon = displayWeapon.Replace("[damage]", description[1]);
            displayWeapon = displayWeapon.Replace("[speed]", description[2]);
            displayWeapon = displayWeapon.Replace("[range]", description[3]);
            display = display.Replace("[name]", weapon.ToString());
            display = display.Replace("[description]", description[0]);
            txt.text = display + "\n" + displayWeapon + ((shopMode) ? ("\n" + displayCost) : (""));
            return;
        }
        if (obj is Iitem) {
            string[] description1 = ((Iitem)obj).DisplayInformation();
			string displayCost = shopFormat;
			displayCost = displayCost.Replace("[cost]", ((Iitem)obj).Cost.ToString());
			display = display.Replace("[name]", obj.ToString());
            display = display.Replace("[description]", description1[0]);
            txt.text = display + ((shopMode) ? ("\n" + displayCost) : (""));
            return;
        }
        txt.text = "";
        equip.SetActive(false);
		eat.SetActive(false);
    }
	public void Clear() {
		Start();
		txt.text = "";
		equip.SetActive(false);
		eat.SetActive(false);
	}
}
