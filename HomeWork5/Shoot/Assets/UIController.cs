using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	private IUserAction action;

	// Use this for initialization
	void Start () {
		action = Director.getInstance ().currentSceneController as IUserAction;
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
