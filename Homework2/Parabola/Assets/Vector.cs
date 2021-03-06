using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour {

	public float vy = 20;
	public float vx = 10;
	private float g = 9.8F;
	public float t = 0;
	public float cha = 0;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (20, 0, -20);	
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.deltaTime;
		this.transform.position -= Vector3.right * t * vx;
		this.transform.position += Vector3.up *(vy + vy - g * t)*t/2;
		vy -= g * t;
	}
}
