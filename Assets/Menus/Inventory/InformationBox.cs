using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationBox : MonoBehaviour {
    GameObject equip;
	EquipScript equipS;
	GameObject eat;
	EatScript eatS;
    Text txt;
    string displayFormat = "Name: [name] \nDescription: [description]";
    string weaponFormat = "Damage: [damage] \nSpeed: [speed] \nRange: [range]";
	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        equip = GameObject.Find("EquipButton");
		equipS = equip.GetComponent<EquipScript>();
		eat = GameObject.Find("EatButton");
		eatS = eat.GetComponent<EatScript>();
        equip.SetActive(false);
		eat.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DisplayObject(object obj) {
        string display = displayFormat;
        if (obj is IEquippable) {
			if (!equip.activeSelf) {
				equip.SetActive(true);
			}
			equipS.obj = obj;
		} else {
            if (equip.activeSelf)
                equip.SetActive(false);
        }
		if (obj is IFood) {
			if (!eat.activeSelf) {
				eat.SetActive(true);
			}
			eatS.obj = obj;
		} else {
			if (eat.activeSelf)
				eat.SetActive(false);
		}
        if (obj is IWeapon) {
            IWeapon weapon = (IWeapon)obj;
            string[] description = weapon.DisplayInformation();
            string displayWeapon = weaponFormat;
            displayWeapon = displayWeapon.Replace("[damage]", description[1]);
            displayWeapon = displayWeapon.Replace("[speed]", description[2]);
            displayWeapon = displayWeapon.Replace("[range]", description[3]);
            display = display.Replace("[name]", weapon.ToString());
            display = display.Replace("[description]", description[0]);
            txt.text = display + "\n" + displayWeapon;
            return;
        }
        if (obj is Iitem) {
            string[] description1 = ((Iitem)obj).DisplayInformation();
            display = display.Replace("[name]", obj.ToString());
            display = display.Replace("[description]", description1[0]);
            txt.text = display;
            return;
        }
        txt.text = "";
        equip.SetActive(false);
		eat.SetActive(false);
    }
}
