using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSun : MonoBehaviour {

    public Transform Sun;
	public Transform Mercury;
	public Transform Venus;
	public Transform Earth;
	public Transform Mars;
	public Transform Jupiter;
	public Transform Saturn;
	public Transform Uranus;
	public Transform Neptune;
    public Transform Moon;

    // Use this for initialization
    void Start () {
		float Random_y = Random.Range (-5, 5);
        Sun.position = Vector3.zero;
		Mercury.position = new Vector3 (27,Random_y, 0);
		Random_y = Random.Range (-5, 5);
		Venus.position = new Vector3 (40,Random_y, 0);
		Random_y = Random.Range (-5, 5);
		Earth.position = new Vector3(50,Random_y, 0);
		Moon.position = new Vector3(50,Random_y + 4, 0);
		Random_y = Random.Range (-5, 5);
		Mars.position = new Vector3 (63,Random_y, 0);
		Random_y = Random.Range (-5, 5);
		Jupiter.position = new Vector3 (78,Random_y, 0);
		Random_y = Random.Range (-5, 5);
		Saturn.position = new Vector3 (95,Random_y, 0);
		Random_y= Random.Range (-5, 5);
		Uranus.position = new Vector3 (107,Random_y, 0);
		Random_y = Random.Range (-5, 5);
		Neptune.position = new Vector3 (120,Random_y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Mercury.RotateAround(Sun.position, Vector3.up, 20 * Time.deltaTime);
		Venus.RotateAround(Sun.position, Vector3.up, 17 * Time.deltaTime);
        Earth.RotateAround(Sun.position, Vector3.up, 16 * Time.deltaTime);
        Moon.transform.RotateAround(Earth.position, Vector3.left, 359 * Time.deltaTime);
		Mars.RotateAround(Sun.position, Vector3.up, 12 * Time.deltaTime);
		Jupiter.RotateAround(Sun.position, Vector3.up, 11 * Time.deltaTime);
		Saturn.RotateAround(Sun.position, Vector3.up, 8 * Time.deltaTime);
		Uranus.RotateAround(Sun.position, Vector3.up, 5 * Time.deltaTime);
		Neptune.RotateAround(Sun.position, Vector3.up, 4 * Time.deltaTime);
	}
}
