using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private IUserAction action;
	public GUISkin MySkin;
	private FirstSceneController firstSceneController;
	private int scrwid = Screen.width;

	void Start(){
		action = Director.getInstance ().currentSceneControl as IUserAction;
		firstSceneController = (FirstSceneController)Director.getInstance ().currentSceneControl;
	}

	void OnGUI(){
		Debug.Log (Director.getInstance ().game_state.ToString());
		GUI.skin = MySkin;
		if(firstSceneController.IfDisplayNum == true &&
			Director.getInstance().game_state == GameState.IN_GAME){
			GUI.Box (new Rect (scrwid/2 - 75, Screen.height/2 - 75, 150, 150), firstSceneController.display_num.ToString());
		}
		if (Director.getInstance ().game_state == GameState.CHOOSE_ROUND) {
			GUI.Label (new Rect (scrwid/2 - 75, 50, 150, 40), "Choose Round");
			if (GUI.Button (new Rect (scrwid/2 - 50, 145, 100, 40), "Easy")) {
				Director.getInstance ().round_state = RoundState.EASY;
				action.Begin ();
			}
			if (GUI.Button (new Rect (scrwid/2 - 50, 195, 100, 40), "Normal")) {
				Director.getInstance ().round_state = RoundState.NORMAL;
				action.Begin ();
			}
			if (GUI.Button (new Rect (scrwid/2 - 50, 245, 100, 40), "Hard")) {
				Director.getInstance ().round_state = RoundState.HARD;
				action.Begin ();
			}
		} else if (Director.getInstance ().game_state == GameState.DISPLAY_SCORE) {
			GUI.Label (new Rect (scrwid/2 - 200, 50, 100, 40), "Score:" + Director.getInstance ().score.ToString ());
			if (GUI.Button (new Rect (scrwid/2 - 50, 50, 100, 40), "Start")) {
				action.Begin ();
			}
			if (GUI.Button (new Rect (scrwid/2 + 70, 50, 130, 40), "Choose Round")) {
				action.ChooseRound ();
			}
		} else if (Director.getInstance ().game_state == GameState.IN_GAME) {
			GUI.Label (new Rect (scrwid/2 - 200, 50, 100, 40), "Score:" + Director.getInstance ().score.ToString ());
			if (GUI.Button (new Rect (scrwid/2 - 20, 50, 100, 40), "Pause")) {
				action.PAUSE ();
			}
			if (GUI.Button (new Rect (scrwid/2 + 100, 50, 100, 40), "End")) {
				action.GameOver ();
			}
		} else if (Director.getInstance ().game_state == GameState.PAUSE) {
			GUI.Label (new Rect (scrwid/2 - 200, 50, 100, 40), "Score:" + Director.getInstance ().score.ToString ());
			if (GUI.Button (new Rect (scrwid/2 - 20, 50, 100, 40), "GoOn")) {
				action.GoOn ();
			}
			if (GUI.Button (new Rect (scrwid/2 + 100, 50, 100, 40), "End")) {
				action.GameOver ();
			}
		} 
	}
}
