using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestory : MonoBehaviour {

	private void OnMouseDown(){
		UFOFactory.getInstance ().releaseUFO (gameObject);
		Director.getInstance ().score += 2;
	}
}
