using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLoop : MonoBehaviour {

    public float runningTrackx;
    public GameObject track1;
    public GameObject track2;
    public GameObject runningTrack;
    public GameObject preparingTrack;
    private float positionLf;
    private float positionRg;

	// Use this for initialization
	void Start () {
        runningTrack = track1;
        preparingTrack = track2;
        positionLf = runningTrack.transform.position.x;
        positionRg = preparingTrack.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

        if (preparingTrack.transform.position.x <= positionLf)
        {
            Debug.Log("TrackLoop!!!");
            runningTrack.transform.position = new Vector3(positionRg, runningTrack.transform.position.y, runningTrack.transform.position.z);
            preparingTrack.transform.position = new Vector3(positionLf, preparingTrack.transform.position.y, preparingTrack.transform.position.z);
            GameObject tmp = runningTrack;
            runningTrack = preparingTrack;
            preparingTrack = tmp;
        }
	}
}
