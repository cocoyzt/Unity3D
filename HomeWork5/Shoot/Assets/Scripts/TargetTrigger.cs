using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour {
	
	public FirstController sceneController;

	// Use this for initialization
	void Start () {
		sceneController = Director.getInstance ().currentSceneController as FirstController;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "arrow") {
			Debug.Log (other.gameObject.name);
			sceneController.score += 1;
			other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			other.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 60f - 3f);
		}
	}
}
