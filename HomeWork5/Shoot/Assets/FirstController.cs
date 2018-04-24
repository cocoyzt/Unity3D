using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction{

	public GameState gamestate = GameState.END;
	public int score = 0;
	public List<GameObject> target = new List<GameObject>();
	private GameObject ArrowPrehab, BowPrehab;
	public GameObject Arrow, Bow;

	void Awake(){
		Director director = Director.getInstance ();
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
	}

	public void LoadResources(){
		//Create target and save into a list
		float largestSize = 10f;
		float firstPostionZ = 60f;
		bool isBlack = true;
		GameObject targetPart;
		for (int i = 0; i < 5; i++) {
			targetPart = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			targetPart.transform.localScale = new Vector3 (largestSize, 0.2f, largestSize);
			targetPart.transform.Rotate(90, 0, 0);
			targetPart.transform.position = new Vector3(0, 0, firstPostionZ);
			targetPart.name = i.ToString ();
			/*targetPart.GetComponent<CapsuleCollider> ().enabled = false;*/
			targetPart.AddComponent<Rigidbody> ();
			targetPart.AddComponent<TargetTrigger> ();
			targetPart.GetComponent<Rigidbody> ().isKinematic = true;
			targetPart.GetComponent<Collider> ().isTrigger = true;
			if (isBlack)
				targetPart.GetComponent<MeshRenderer> ().material.color = Color.black;
			else
				targetPart.GetComponent<MeshRenderer> ().material.color = Color.white;
			largestSize -= 2f;
			firstPostionZ -= 0.2f;
			isBlack = !isBlack;
			target.Add (targetPart);
		}

		//Load arrow and bow prefab
		ArrowPrehab = Resources.Load("Prefabs/arrow", typeof(GameObject)) as GameObject;
		BowPrehab = Resources.Load("Prefabs/bow", typeof(GameObject)) as GameObject;

		//Instantiate arrow and bow
		Arrow = Instantiate(ArrowPrehab, new Vector3(0, 0, -2f), Quaternion.identity);
		Bow = Instantiate(BowPrehab, new Vector3(0, 0, 0), Quaternion.identity);
		Arrow.transform.localScale = new Vector3 (200f, 200f, 200f);
		Bow.transform.localScale = new Vector3 (200f, 200f, 200f);
		Arrow.transform.Rotate (0, -90, 90);
		Bow.transform.Rotate (0, -90, 0);
		Arrow.transform.parent = Bow.transform;
		Bow.AddComponent<MoveBow> ();
	}

	public void Pause(){
		gamestate = GameState.PAUSE;
	}

	public void Begin(){
		gamestate = GameState.INGAME;
	}

	public void End(){
		gamestate = GameState.END;
	}

	public GameState getGamestate (){
		return gamestate;
	}

	public int getScore(){
		return score;
	}

	// Use this for initialization
	void Start () {
		
	}
}
