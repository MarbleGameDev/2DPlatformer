using UnityEngine;
using System.Collections;

namespace UnityEngine.UI.Extensions{
public class ResolutionDropdown : DropDownBase {
	DropDownList dropList;
	public Text txt;
	Resolution[] resolutions;
	// Use this for initialization
	void Start () {
		dropList = GetComponent<DropDownList> ();
		resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++) {
			DropDownListItem newButton = new DropDownListItem (ResToString(resolutions[i]));
			dropList.AddItems (newButton);
		}
		txt.text = ResToString(Screen.currentResolution);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public override void GetButtonClick(int indx){
			Screen.SetResolution (resolutions [indx].width, resolutions [indx].height, Settings.fullscreen);
	}

		private string ResToString(Resolution res){
			return res.width + " x " + res.height;
		}
}
}