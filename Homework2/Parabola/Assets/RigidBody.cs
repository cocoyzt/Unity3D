using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody : MonoBehaviour {

	public float vy = 15;
	public float vx = 10;
	public float t = 0;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (10, 0, -20);	
		t = 0;
	}

	// Update is called once per frame
	void Update () {
		t = Time.deltaTime;
		this.transform.position -= Vector3.right * t * vx;
		this.transform.position += Vector3.up * t * vy;
	}
}
