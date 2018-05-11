using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAction : MonoBehaviour {

	private FirstController fircon;
	// Use this for initialization
	void Start () {
		fircon = (FirstController)Director.getInstance ().currentSceneController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collider)  
	{  
		if (collider.gameObject.name == "Hero") {
			Debug.Log ("!!!");
			fircon.gamestate = GameState.END;
		}
	}  
}
