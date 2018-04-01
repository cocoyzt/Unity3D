using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfrom : MonoBehaviour {

	public float vy = 20;
	public float vx = 10;
	private float g = 9.8F;
	public float t = 0;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (20, 0, 0);
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
			this.transform.position = new Vector3 (20 - vx * t, vy * t - t * t * g, 0);
	}
}
