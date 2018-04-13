using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private IUserAction action;
	public GUISkin MySkin;

	void Start(){
		action = Director.getInstance ().currentSceneControl as IUserAction;
	}

	void OnGUI(){
		GUI.skin = MySkin;
		if (Director.getInstance().game_state == GameState.CHOOSE_ROUND) {
			GUI.Label (new Rect (600, 50, 100, 40), "Choose Round!");
			if (GUI.Button (new Rect (600, 200, 100, 40), "Easy")) {
				Director.getInstance ().round_state = RoundState.EASY;
				action.Begin ();
			}
			if (GUI.Button (new Rect (600, 250, 100, 40), "Normal")) {
				Director.getInstance ().round_state = RoundState.NORMAL;
				action.Begin ();
			}
			if (GUI.Button (new Rect (600, 300, 100, 40), "Hard")) {
				Director.getInstance ().round_state = RoundState.HARD;
				action.Begin ();
			}
		} else if (Director.getInstance().game_state == GameState.DISPLAY_SCORE) {
			GUI.Label (new Rect (500, 50, 200, 80), "Score:" + Director.getInstance ().score.ToString());
			if (GUI.Button (new Rect (600, 50, 100, 40), "ReStart")) {
				action.ReStart();
			}
			if (GUI.Button (new Rect (700, 50, 100, 40), "Choose Round")) {
				action.ChooseRound ();
			}
		} else if (Director.getInstance().game_state == GameState.IN_GAME) {
			GUI.Label (new Rect (500, 50, 200, 80), "Score:" + Director.getInstance ().score.ToString());
			if (GUI.Button (new Rect (600, 50, 100, 40), "Pause")) {
				action.PAUSE ();
			}
			if (GUI.Button (new Rect (700, 50, 100, 40), "End")) {
				action.GameOver ();
			}
		} else if (Director.getInstance().game_state == GameState.PAUSE) {
			if (GUI.Button (new Rect (600, 50, 100, 40), "GoOn")) {
				action.GoOn ();
			}
			GUI.Label (new Rect (400, 50, 400, 400), "Pausing!!!");
		}
	}
}
