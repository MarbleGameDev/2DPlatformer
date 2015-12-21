using UnityEngine;
using System.Collections;
namespace UnityEngine.UI.Extensions{
	public class VSync : DropDownBase {
		DropDownList dropList;
		public Text txt;
		void Start () {
				dropList = GetComponent<DropDownList> ();
				dropList.AddItems (new DropDownListItem ("No"));
				dropList.AddItems (new DropDownListItem ("Yes"));
				txt.text = (QualitySettings.vSyncCount == 0) ? ("No") : ("Yes");
		}
		
		// Update is called once per frame
		void Update () {

		}

		public override void GetButtonClick(int indx){
			QualitySettings.vSyncCount = indx;
		}
	}
}
