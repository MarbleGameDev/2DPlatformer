using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemExecution : MonoBehaviour {
    public object item;
    private bool isSelected;
    private static Transform selected;
    InformationBox infoTxt;
    void Start() {
        infoTxt = GameObject.Find("Item Information").GetComponentInChildren<InformationBox>();
    }
	public void Click(){
        if (!isSelected) {
            GetComponent<Text>().fontStyle = FontStyle.Bold;
            isSelected = true;
            selected = this.transform;
            infoTxt.DisplayObject(item);
        } else {
            isSelected = false;
            infoTxt.DisplayObject(null);
            GetComponent<Text>().fontStyle = FontStyle.Normal;
        }
	}
    void Update() {
        if (isSelected) {
            if (selected != this.transform) {
                isSelected = false;
                GetComponent<Text>().fontStyle = FontStyle.Normal;
            }
        }
    }
}
