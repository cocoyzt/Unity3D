using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour ,ISceneController, IUserAction{
	
	public int NumOfUFO = 0;
	public int SpeedOfUFO = 0;
	public int ScoreOfUFO = 0;
	public int TotalUFO = 0;
	public GameObject UFO;

	public void Awake(){
		Director.getInstance ().currentSceneControl = this;
		if(Director.getInstance ().currentSceneControl != null) Debug.Log ("NOTEMPTY");
		UFO = (GameObject)Resources.Load ("UAV Trident");
	}

	public void GenGameObjects (){
		Director.getInstance ().score = 0;
		TotalUFO = 0;
	}

	public void ReStart (){
		GenGameObjects ();
		Director.getInstance ().game_state = GameState.IN_GAME;
		this.Begin ();
	}

	public void Begin (){
		SetNumSpeed ();
		Director.getInstance ().game_state = GameState.IN_GAME;
		InvokeRepeating ("CreateUFO", 3f, 1f);
	}

	public void GameOver (){
		Director.getInstance ().game_state = GameState.END;
		this.DisplayScore ();
	}
	public void DisplayScore (){
		Director.getInstance ().game_state = GameState.DISPLAY_SCORE;
		if(IsInvoking()) CancelInvoke();
	}
	public void ChooseRound (){
		Director.getInstance ().game_state = GameState.CHOOSE_ROUND;
	}
	public void PAUSE (){
		Director.getInstance ().game_state = GameState.PAUSE;
		if(IsInvoking()) CancelInvoke();
	}
	public void GoOn (){
		Director.getInstance ().game_state = GameState.IN_GAME;
		InvokeRepeating ("CreateUFO", 3f, 1f);
	}
		
	public void SetNumSpeed(){
		if (Director.getInstance ().round_state == RoundState.EASY) {
			NumOfUFO = 10;
			SpeedOfUFO = 1;
			ScoreOfUFO = 4;
		}else if (Director.getInstance ().round_state == RoundState.EASY) {
			NumOfUFO = 20;
			SpeedOfUFO = 1;
			ScoreOfUFO = 2;
		}
		else {
			NumOfUFO = 20;
			SpeedOfUFO = 2;
			ScoreOfUFO = 2;
		}
	}

	public void CreateUFO(){
		GameObject UFOtemp = Instantiate (UFO);
		UFOtemp.transform.localScale = new Vector3 (3f, 3f, 3f);
		UFOtemp.transform.Rotate(90, 0, 0);
		UFOtemp.transform.position = new Vector3 (Random.Range(-5f, 5f), Random.Range(0, 5f), 0);
		UFOtemp.AddComponent<ClickToDestory> ();
		UFOtemp.AddComponent<AddSpeed> ();
		TotalUFO++;
	}

	public void Update(){
		if (TotalUFO > NumOfUFO) {
			CancelInvoke();
			this.GameOver ();
		}
	}
}
