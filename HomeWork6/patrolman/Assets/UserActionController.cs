using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserActionController : MonoBehaviour {

	private FirstController action;
	public float speed;
	public GameObject hero;

	// Use this for initialization
	void Start () {
		action = Director.getInstance ().currentSceneController as FirstController;
		hero = action.Hero;
		speed = 15f;
	}

	void OnGUI(){
		if (action.getGamestate () == GameState.INGAME) {
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Pause")){
				action.Pause ();
			}
			if(GUI.Button(new Rect(0, 100, 80, 40), "End")){
				action.End ();
			}
		}
		else if (action.getGamestate () == GameState.END) {
			GUI.Label (new Rect(0, 100, 80, 40), "GameOver!!");
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Start")){
				action.Begin ();
			}
		}
		else if (action.getGamestate () == GameState.PAUSE) {
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Go on")){
				action.Begin ();
			}
			if(GUI.Button(new Rect(0, 100, 80, 40), "End")){
				action.End ();
			}
		}
	}

	void Update(){
		if (action.getGamestate () == GameState.INGAME) {
			float translationX = Input.GetAxis ("Horizontal") * speed;
			float translationZ = Input.GetAxis ("Vertical") * speed;
			translationX *= Time.deltaTime;
			translationZ *= Time.deltaTime;
			hero.transform.Translate (translationX, 0, 0);
			hero.transform.Translate (0, 0, translationZ);
		}
	}
}
