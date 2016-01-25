using UnityEngine;
using System.Collections;

public class TutorialQuest : MonoBehaviour, IQuest {
    public static string state;
    public string StatusUpdate()
    {   //Gets called any time the game wants to know what the status of the quest is, also when the quest is first started
        //InventoryData.OnChange += InvUpdate;    //start listening to inventory updates
        if (state.Equals(""))
        {
            state = PlayerPrefs.GetString("SampleQuest", "blanke");     //if the file is just initialized, read the data from disk, default to "blank" if it's the first time
        }
        PlayerPrefs.SetString("SampleQuest", state);    //Store the data again in case it changes
        switch (state)
        {   //switch between the set states
            case "blank":   //blank state can be used as a startup function
                NotificationManager.AddNotification("Quest Started", "Started SampleQuest");    //Adding notification that the quest started
                state = "Pick up Diary (0/1)";
                break;
            case "Pick up Diary (0/1)":
                break;
            case "Pick up Diary (1/1)":
                state = "Finished";
                NotificationManager.AddNotification("Quest Complete", "Finished SampleQuest");  //adding notification that the quest is finished
                                                                                                //InventoryData.OnChange -= InvUpdate; 	//stop listening to inventory updates
                PlayerPrefs.Save();     //Writes all data changes to disk just in case
                break;
        }
        return state;   //Return a string stating the status of the quest
    }
}
