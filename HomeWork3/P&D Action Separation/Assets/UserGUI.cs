using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

	private IUserAction action;

	void Start(){
		action = Director.getInstance ().currentSceneControl as IUserAction;
	}

	private void OnGUI(){
		if (GUI.Button (new Rect (450, 100, 100, 40), "GO") && action.getGameState () == GameState.NOT_ENDED)
			action.MoveBoat ();

		if(action.getGameState() == GameState.WIN)
			GUI.Label (new Rect (490, 50, 800, 450), "Win!");

		if (action.getGameState () == GameState.FAILED)
			action.GameOver ();
	}
}
