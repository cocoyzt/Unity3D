using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBow : MonoBehaviour {

	public float speedX = 2f;
	public float speedY = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float translationY = Input.GetAxis ("Vertical") * speedY;
		float translationX = Input.GetAxis ("Horizontal") * speedX;
		translationX *= Time.deltaTime;
		translationY *= Time.deltaTime;
		transform.Translate (0, translationY, 0);
		transform.Translate (0, 0, -translationX);
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("shoot!");
			GameObject shootedArrow = Instantiate((GameObject)Resources.Load("Prefabs/arrow", typeof(GameObject)), this.transform.position, Quaternion.identity);
			shootedArrow.name = "arrow";
			shootedArrow.transform.localScale = new Vector3 (200f, 200f, 200f);
			shootedArrow.transform.Rotate (0, -90, 90);
			shootedArrow.AddComponent<Rigidbody> ();
			shootedArrow.GetComponent<Rigidbody> ().AddForce(0, 0, 4000);
			shootedArrow.GetComponent<Rigidbody> ().useGravity = true;
			shootedArrow.AddComponent<BoxCollider>();
			shootedArrow.GetComponent<BoxCollider> ().isTrigger = true;
		}
	}
}
