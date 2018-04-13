using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : System.Object {

	private static UFOFactory _instance;
	public List<GameObject> usingUFO;
	private List<GameObject> usedUFO;
	private GameObject ExplosionPrefab;

	public static UFOFactory getInstance(){
		if (_instance == null)
			_instance = new UFOFactory ();
		return _instance;
	}

	private UFOFactory(){
		usingUFO = new List<GameObject>();
		usedUFO = new List<GameObject>();

		ExplosionPrefab = Resources.Load ("Explosion", typeof(GameObject)) as GameObject;
	}

	public GameObject getNewUFO(){
		GameObject newUFO;

		if (usedUFO.Count == 0) {
			newUFO = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			usingUFO.Add (newUFO);
		} else {
			newUFO = usedUFO [0];
			usedUFO.Remove (newUFO);
			usingUFO.Add (newUFO);
			newUFO.SetActive (true);
		}

		int color = Random.Range (0, 4);
		int LfOrRg = Random.Range (0, 2);
		/*GameObject UFOtemp = Instantiate (UFO);*/
		newUFO.transform.localScale = new Vector3 (3f, 0.2f, 3f);
		newUFO.transform.Rotate(Random.Range(-30, 30), 0, 0);
		if(LfOrRg == 0) newUFO.transform.position = new Vector3 (Random.Range(12f, 20f), Random.Range(-5f, 5f), -10);
		else newUFO.transform.position = new Vector3 (Random.Range(-20f, 12f), Random.Range(-5f, 5f), -10);
		newUFO.AddComponent<ClickToDestory> ();
		newUFO.AddComponent<AddSpeed> ();
		if (color == 0)
			newUFO.GetComponent<MeshRenderer> ().material.color = Color.blue;
		else if (color == 1)
			newUFO.GetComponent<MeshRenderer> ().material.color = Color.red;
		else
			newUFO.GetComponent<MeshRenderer> ().material.color = Color.green;

		return newUFO;
	}

	public void releaseUFO(GameObject UFOtoRelease){
		usingUFO.Remove (UFOtoRelease);
		usingUFO.Add (UFOtoRelease);
		UFOtoRelease.SetActive (false);

		/*Instantiate explosion*/
		UnityEngine.Object.Instantiate (ExplosionPrefab, UFOtoRelease.transform.position, Quaternion.identity);
	}
}
