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
            if (QuestDictionary.Quests.ContainsKey(questNames[i])){
                if (node < Quests[i].states.Length){    //if the node checked has a qualifier, true if not
					if ((Quests[i].states[node]).Contains("!")) {   //Return the result if the state is not such
						string newState = Quests[i].states[node].Replace("!", "");
						if (Quests[i].states[node] != null && !newState.Equals(QuestDictionary.GetUpdate(questNames[i])) || Quests[i].states[node].Equals("true"))
							return true;
					} else if ((Quests[i].states[node]).Contains("...")) {
						string newState = Quests[i].states[node].Replace("...", "");
						if (Quests[i].states[node] != null && (QuestDictionary.GetUpdate(questNames[i])).Contains(newState) || Quests[i].states[node].Equals("true"))
							return true;
					} else {    //Return the result if the state is such
						if (Quests[i].states[node] != null && Quests[i].states[node].Equals(QuestDictionary.GetUpdate(questNames[i])) || Quests[i].states[node].Equals("true"))
							return true;
					}
                } else {
                    return true;
                }
            }
		}
		return false;
	}
}
