using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	private FirstController action;

	// Use this for initialization
	void Start () {
		action = Director.getInstance ().currentSceneController as FirstController;
	}
	
	void OnGUI(){
		if (action.getGamestate () == GameState.INGAME) {
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore ().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Pause")){
				action.Pause ();
			}
			if(GUI.Button(new Rect(0, 100, 80, 40), "End")){
				action.End ();
			}
			GUI.Label (new Rect (0, 150, 150, 40), "Wind:" + Mathf.Abs(action.windForce).ToString () + 
				(action.windForce > 0? " right":" left"));
		}
		else if (action.getGamestate () == GameState.END) {
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore ().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Start")){
				action.Begin ();
			}
		}
		else if (action.getGamestate () == GameState.PAUSE) {
			GUI.Label (new Rect (0, 0, 80, 40), "Score:" + action.getScore ().ToString ());
			if(GUI.Button(new Rect(0, 50, 80, 40), "Go on")){
				action.Begin ();
			}
			if(GUI.Button(new Rect(0, 100, 80, 40), "End")){
				action.End ();
			}
		}
	}
}
