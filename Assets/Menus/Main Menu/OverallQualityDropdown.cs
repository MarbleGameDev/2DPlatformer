using UnityEngine;
using System.Collections;
namespace UnityEngine.UI.Extensions{
public class OverallQualityDropdown : DropDownBase {
	DropDownList dropList;
	public Text txt;
	// Use this for initialization
	void Start () {
		dropList = GetComponent<DropDownList> ();
		for (int i = 0; i < QualitySettings.names.Length; i++) {
			DropDownListItem newButton = new DropDownListItem (QualitySettings.names[i]);
			dropList.AddItems (newButton);
		}
			txt.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public override void GetButtonClick(int indx){
			QualitySettings.SetQualityLevel (indx);
	}
	}
}
