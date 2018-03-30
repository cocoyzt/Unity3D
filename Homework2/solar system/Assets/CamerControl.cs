using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour {

	public Camera MainCamera;
	public Camera CameraUp;
	public Camera EarthCamera;

	// Use this for initialization
	void Start () {
		MainCamera.enabled = true;
		CameraUp.enabled = false;
		EarthCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 100, 45), "Main Camera")) {
			MainCamera.enabled = true;
			CameraUp.enabled = false;
			EarthCamera.enabled = false;
		}
		if (GUI.Button (new Rect (10, 65, 100, 45), "Earth Camera")) {
			MainCamera.enabled = false;
			CameraUp.enabled = false;
			EarthCamera.enabled = true;
		}
		if (GUI.Button (new Rect (10, 120, 80, 45), "Up Camera")) {
			MainCamera.enabled = false;
			CameraUp.enabled = true;
			EarthCamera.enabled = false;
		}
	}
}
