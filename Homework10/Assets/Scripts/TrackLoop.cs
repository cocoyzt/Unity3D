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
        positionLf = runningTrack.transform.position.z;
        positionRg = preparingTrack.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {

        if (preparingTrack.transform.position.z <= positionLf)
        {
            Debug.Log("TrackLoop!!!");
            runningTrack.transform.position = new Vector3(preparingTrack.transform.position.x, runningTrack.transform.position.y, positionRg);
            preparingTrack.transform.position = new Vector3(preparingTrack.transform.position.x, preparingTrack.transform.position.y, positionLf);
            GameObject tmp = runningTrack;
            runningTrack = preparingTrack;
            preparingTrack = tmp;
        }
	}
}
