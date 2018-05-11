using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : MonoBehaviour {

	public int index;
	public int dir = 0;
	private float BirthX = 0f;
	private float BirthZ = 0f;
	private double nextFire = 0;
	private FirstController fircon;
	private float max_x;
	private float min_x;
	private float max_z;
	private float min_z;
	private Vector3 disv3;


	// Use this for initialization
	void Start () {
		fircon = (FirstController)Director.getInstance ().currentSceneController;
		index = int.Parse (this.transform.name);
		BirthX = (float)(20 - (index % 3) * 20);
		BirthZ = (float)(20 - (index / 3) * 20);
		max_x = BirthX + 10;
		min_x = BirthX - 10;
		max_z = BirthZ + 10;
		min_z = BirthZ - 10;
		disv3 = new Vector3 (Random.Range(min_x + 2, max_x - 2), 0.6f, Random.Range(min_z + 2, max_z - 2));
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (fircon.gamestate != GameState.END) {
			if (Time.time > nextFire) {
				float x = this.transform.position.x;
				float z = this.transform.position.z;
				//judge if hero is in patrol's block
				if (index == fircon.hero_index) {
					Catch ();
				} else {
					Patrol (x, z);
				}
				nextFire = Time.time + 0.5;
			}
		}
	}

	public void Catch (){
		transform.position = Vector3.MoveTowards (this.transform.position, fircon.Hero.transform.position, 1f);
		/*if (fircon.Hero.transform.position.x > x) {
			this.transform.Translate (x + 0.5f, 0, z);
		} else if (fircon.Hero.transform.position.x < x) {
			this.transform.Translate (x - 0.5f, 0, z);
		} 
		if (fircon.Hero.transform.position.z > z) {
			this.transform.Translate (x, 0, z + 0.5f);
		} else if (fircon.Hero.transform.position.z < z) {
			this.transform.Translate (x, 0, z - 0.5f);
		} */
	}

	public void Patrol(float x, float z){
		if ((this.transform.position.x < disv3.x + 1) && (this.transform.position.x > disv3.x - 1)&&
			(this.transform.position.z < disv3.z + 1) && (this.transform.position.z > disv3.z - 1)) {
			disv3 = new Vector3 (Random.Range(min_x + 2, max_x - 2), 0.6f, Random.Range(min_z + 2, max_z - 2));
		} else {
			transform.position = Vector3.MoveTowards (this.transform.position, disv3, 1f);
		}
	}
		
	void OnCollisionEnter(Collision collider)  
	{  
		if (collider.gameObject.name == "Hero") {
			Debug.Log ("!!!");
			fircon.gamestate = GameState.END;
		}
	}  
}
