using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestory : MonoBehaviour {

	private void OnMouseDown(){
		Destroy (gameObject, 0);
		Debug.Log ("Clicking!");
		Director.getInstance ().score += 2;
	}
}
