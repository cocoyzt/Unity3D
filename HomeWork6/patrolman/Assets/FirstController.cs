using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction{

	public GameState gamestate = GameState.END;
	public int score = 0;
	public GameObject Hero;
	public GameObject Patrol;
	public int hero_index = 4;

	void AddScore(){
		score++;
	}
		
	void Awake(){
		GameEventManager.addScore += AddScore;
		Director director = Director.getInstance ();
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
	}

	public void LoadResources(){
		//create grounds
		GameObject groundpart;
		bool isBlack = false;
		for (int i = 0; i < 9; i++) {
			groundpart = GameObject.CreatePrimitive (PrimitiveType.Cube);
			groundpart.transform.localScale = new Vector3 (20f, 0.1f, 20f);
			groundpart.transform.position = new Vector3 ((float)(20 - (i%3)*20), 0f, (float)(20 - (i/3)*20));
			groundpart.name = "Ground" + i.ToString ();
			groundpart.AddComponent<Rigidbody> ();
			groundpart.GetComponent<Rigidbody> ().isKinematic = true;
			if (isBlack)
				groundpart.GetComponent<MeshRenderer> ().material.color = Color.black;
			else
				groundpart.GetComponent<MeshRenderer> ().material.color = Color.white;
			isBlack = !isBlack;
		}

		//create long wall
		for (int i = 0; i < 4; i++) {
			groundpart = GameObject.CreatePrimitive (PrimitiveType.Cube);
			switch (i) {
			case 0:
				groundpart.transform.localScale = new Vector3 (60f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (0f, 0f, 30f);
				break;
			case 1:
				groundpart.transform.localScale = new Vector3 (60f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (0f, 0f, -30f);
				break;
			case 2:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 60f);
				groundpart.transform.position = new Vector3 (30f, 0f, 0f);
				break;
			case 3:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 60f);
				groundpart.transform.position = new Vector3 (-30f, 0f, 0f);
				break;
			}
			groundpart.name = "Wallllll" + i.ToString ();
			groundpart.AddComponent<Rigidbody> ();
			groundpart.GetComponent<Rigidbody> ().isKinematic = true;
			groundpart.AddComponent<WallAction> ();
		}

		//create wall
		for (int i = 0; i < 8; i++) {
			groundpart = GameObject.CreatePrimitive (PrimitiveType.Cube);
			switch (i) {
			case 0:
				groundpart.transform.localScale = new Vector3 (26f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (15f, 0f, 10f);
				break;
			case 1:
				groundpart.transform.localScale = new Vector3 (26f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (15f, 0f, -10f);
				break;
			case 2:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 26f);
				groundpart.transform.position = new Vector3 (10f, 0, 15f);
				break;
			case 3:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 26f);
				groundpart.transform.position = new Vector3 (10f, 0, -15f);
				break;
			case 4:
				groundpart.transform.localScale = new Vector3 (26f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (-15f, 0f, -10f);
				break;
			case 5:
				groundpart.transform.localScale = new Vector3 (26f, 2f, 0.5f);
				groundpart.transform.position = new Vector3 (-15f, 0f, 10f);
				break;
			case 6:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 26f);
				groundpart.transform.position = new Vector3 (-10f, 0, 15f);
				break;
			case 7:
				groundpart.transform.localScale = new Vector3 (0.5f, 2f, 26f);
				groundpart.transform.position = new Vector3 (-10f, 0, -15f);
				break;
			}
			groundpart.name = "Wall" + i.ToString ();
			groundpart.AddComponent<Rigidbody> ();
			groundpart.GetComponent<Rigidbody> ().isKinematic = true;
			groundpart.AddComponent<WallAction> ();
		}

		//create hero
		Hero = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Hero.name = "Hero";
		Hero.transform.localScale = new Vector3 (1f, 1f, 1f);
		Hero.transform.position = new Vector3 (8f, 0.6f, 8f);
		Hero.GetComponent<MeshRenderer> ().material.color = Color.yellow;
		Hero.AddComponent<Rigidbody> ();

		//create patrol
		for (int i = 0; i < 9; i++) {
			Patrol = GameObject.CreatePrimitive(PrimitiveType.Cube);
			Patrol.name = i.ToString();
			Patrol.transform.localScale = new Vector3 (2f, 2f, 2f);
			Patrol.transform.position = new Vector3 ((float)(20 - (i%3)*20), 0.6f, (float)(20 - (i/3)*20));
			Patrol.GetComponent<MeshRenderer> ().material.color = Color.red;
			Patrol.AddComponent<Rigidbody> ();
			Patrol.AddComponent<PatrolAction> ();
			/*Patrol.GetComponent<Rigidbody> ().isKinematic = true;*/
		}
	}

	public void Pause(){
		gamestate = GameState.PAUSE;
	}

	public void Begin(){
		gamestate = GameState.INGAME;
	}

	public void End(){
		gamestate = GameState.END;
		score = 0;
	}

	public GameState getGamestate (){
		return gamestate;
	}

	public int getScore(){
		return score;
	}

	// Use this for initialization
	void Update () {
		float hero_x = Hero.transform.position.x;
		float hero_z = Hero.transform.position.z;
		if (hero_z > 10 && hero_z < 30) {
			if (hero_x > 10 && hero_x < 30)
				hero_index = 0;
			else if (hero_x > -10 && hero_x < 10)
				hero_index = 1;
			else if (hero_x > -30 && hero_x < -10)
				hero_index = 2;
		}
		else if (hero_z > -10 && hero_z < 10) {
			if (hero_x > 10 && hero_x < 30)
				hero_index = 3;
			else if (hero_x > -10 && hero_x < 10)
				hero_index = 4;
			else if (hero_x > -30 && hero_x < -10)
				hero_index = 5;
		}
		else if (hero_z > -30 && hero_z < -10) {
			if (hero_x > 10 && hero_x < 30)
				hero_index = 6;
			else if (hero_x > -10 && hero_x < 10)
				hero_index = 7;
			else if (hero_x > -30 && hero_x < -10)
				hero_index = 8;
		}
	}
		
}
