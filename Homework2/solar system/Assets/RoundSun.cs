using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSun : MonoBehaviour {

    public Transform Sun;
    public Transform Earth;
    public Transform Moon;

    // Use this for initialization
    void Start () {
        Sun.position = Vector3.zero;
        Earth.position = new Vector3(50, 0, 0);
        Moon.position = new Vector3(40, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Earth.RotateAround(Sun.position, Vector3.up, 10 * Time.deltaTime);
        Earth.Rotate(Vector3.up * 30 * Time.deltaTime);
        Moon.transform.RotateAround(Earth.position, Vector3.up, 359 * Time.deltaTime);
	}
}
