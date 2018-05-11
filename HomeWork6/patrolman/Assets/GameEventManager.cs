using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {  
	public delegate void AddScore();//委托  
	public static event AddScore addScore;//事件  
	// Use this for initialization  

	void OnTriggerEnter(Collider collider)  
	{  
		if (collider.gameObject.name == "Hero") {  
			Debug.Log ("hit by hero");
			add ();
		}
	}  

	void add()  
	{  
		if(addScore != null)  
		{  
			addScore();
		}  
	}  
}  
