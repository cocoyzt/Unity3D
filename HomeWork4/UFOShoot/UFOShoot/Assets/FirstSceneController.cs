using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour ,ISceneController, IUserAction{
	
	public int score = 0;

	public void Awake(){
		Director.getInstance ().currentSceneControl = this;
		if(Director.getInstance ().currentSceneControl != null) Debug.Log ("NOTEMPTY");
	}

	public void GenGameObjects (){
		score = 0;
	}

	public void ReStart (){
		GenGameObjects ();
		Director.getInstance ().game_state = GameState.IN_GAME;
	}

	public void Begin (){
		Director.getInstance ().game_state = GameState.IN_GAME;
	}

	public void GameOver (){
		Director.getInstance ().game_state = GameState.END;
	}
	public void DisplayScore (){
		Director.getInstance ().game_state = GameState.DISPLAY_SCORE;
	}
	public void ChoseRound (){
		Director.getInstance ().game_state = GameState.CHOOSE_ROUND;
	}
	public void PAUSE (){
		Director.getInstance ().game_state = GameState.PAUSE;
	}
	public void GoOn (){
		Director.getInstance ().game_state = GameState.IN_GAME;
	}

	public int getScore(){
		return score;
	}
}
