using UnityEngine;
using System.Collections;

public interface Iitem{
	void Use();
	void Drop();
    string ToString();  //Must be the same of each object for them to stack
}
