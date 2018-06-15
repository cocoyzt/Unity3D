using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Director.GetInstance().playing = false;
        Debug.Log("Die!!");
    }
}
