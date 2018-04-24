using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	private FirstController sceneController;

	// Use this for initialization
	void Start () {
		sceneController = Director.getInstance ().currentSceneController as FirstController;
	}
	
	private void OnTriggerStay(Collider other){
		if (other.gameObject.name == "arrow") {
			other.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(sceneController.windForce, 0, 0));
		}
	}
}
