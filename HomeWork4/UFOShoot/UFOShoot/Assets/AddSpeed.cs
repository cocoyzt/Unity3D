using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour {

	public float speed_vz;
	public float speed_vx;
	public float speed_vy = 0;
	private float g = 9.8f;
	public float t = 0;
	private FirstSceneController firstSceneController;

	// Use this for initialization
	void Start () {
		firstSceneController = (FirstSceneController)Director.getInstance ().currentSceneControl;
		speed_vz = firstSceneController.SpeedOfUFO;
		speed_vx = Random.Range (-5f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.deltaTime;
		gameObject.transform.position += Vector3.left * t * speed_vx;
		gameObject.transform.position += Vector3.forward * t * speed_vz;
		gameObject.transform.position += Vector3.up * (speed_vy + speed_vy -g *t) *t/2;
		speed_vy -= g * t;
	}
}
