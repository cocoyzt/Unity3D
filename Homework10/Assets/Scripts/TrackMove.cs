using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Director.GetInstance().playing)
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.08f);
	}
}
