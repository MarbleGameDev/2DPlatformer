using UnityEngine;
using System.Collections;

public class CheckQuest : MonoBehaviour, ICheckData {
	[System.Serializable]
	public class States{
		public string[] states;
	}

	[Tooltip ("Quests in order by priority of dialogue scripts")]
	public States[] Quests;
	public string[] questNames;
	public bool CheckData(int node){
		for (int i = 0; i < Quests.Length; i++) {
			if (QuestDictionary.Quests.ContainsKey(questNames[i]) && node <= Quests.Length){
				if (Quests[i].states[node] != null && Quests[i].states[node].Equals(QuestDictionary.GetUpdate(questNames[i])) || Quests[i].states[node].Equals("true"))
					return true;
			}
		}
		return false;
	}
}
