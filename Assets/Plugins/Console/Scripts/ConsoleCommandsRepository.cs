using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate string ConsoleCommandCallback(params string[] args);

public class ConsoleCommandsRepository {
  private static ConsoleCommandsRepository instance;
  private Dictionary<string, ConsoleCommandCallback> repository;
	private Dictionary<string, string> repoList;

  public static ConsoleCommandsRepository Instance {
    get {
      if (instance == null) {
        instance = new ConsoleCommandsRepository();
      }
      return instance;
    }
  }
  public ConsoleCommandsRepository() {
    repository = new Dictionary<string, ConsoleCommandCallback>();
		repoList = new Dictionary<string, string> ();
  }

  public void RegisterCommand(string command, ConsoleCommandCallback callback) {
    repository[command] = new ConsoleCommandCallback(callback);
	if (!repoList.ContainsKey (command)) {
			repoList.Add (command, command);
		}
  }

  public bool HasCommand(string command) {
    return repository.ContainsKey(command);
  }

  public string ExecuteCommand(string command, string[] args) {
    if (HasCommand(command)) {
      return repository[command](args);
    } else {
      return "Command not found";
    } 
  }

  public void getDictionary(){
		var logger = ConsoleLog.Instance;
		foreach (string cKey in repository.Keys){
			logger.Log(cKey);
		}
	}
}
