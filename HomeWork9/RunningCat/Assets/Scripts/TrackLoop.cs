using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLoop : MonoBehaviour {

    public float runningTrackx;
    public GameObject track1;
    public GameObject track2;
    public GameObject runningTrack;
    public GameObject preparingTrack;

	// Use this for initialization
	void Start () {
        runningTrack = track1;
        preparingTrack = track2;
    }
	
	// Update is called once per frame
	void Update () {
        runningTrackx = runningTrack.transform.position.x;

        if (runningTrack.transform.position.x <= -64f)
        {
            Debug.Log("TrackLoop!!!");
            runningTrack.transform.position = new Vector3(40.6f, runningTrack.transform.position.y, runningTrack.transform.position.z);
            GameObject tmp = runningTrack;
            runningTrack = preparingTrack;
            preparingTrack = tmp;
        }
	}
}
