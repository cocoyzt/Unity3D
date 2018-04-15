using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour ,ISceneController, IUserAction{

	public List<GameObject> ExplosionList = new List<GameObject>();
	public int NumOfUFO = 10;
	public int SpeedOfUFO = 0;
	public int ScoreOfUFO = 0;
	public int display_num = 4;
	public int usingUFONum = 0;
	public float timeEachUFO = 0;
	public bool IfDisplayNum = false;
	public int UsedUFONum = 0;
	public GameState gamestate = GameState.CHOOSE_ROUND;
	/*public GameObject UFO;*/

	public void Awake(){
		Director.getInstance ().currentSceneControl = this;
		/*UFO = (GameObject)Resources.Load ("UAV Trident");*/
		this.ChooseRound ();
	}

	public void GenGameObjects (){
		UsedUFONum = 0;
		Director.getInstance ().score = 0;
		SetNumSpeed ();
	}

	public void ReStart (){
		/*
		GenGameObjects ();
		Director.getInstance ().game_state = GameState.IN_GAME;
		this.Begin ();
		*/
	}

	public void Begin (){
		GenGameObjects ();
		Director.getInstance ().game_state = GameState.IN_GAME;
		InvokeRepeating ("CreateUFO", 3f, timeEachUFO);
		display_num = 4;
		InvokeRepeating ("DisplayNum", 0f, 1f);
	}

	public void GameOver (){
		CancelInvoke("CreateUFO");
		CancelInvoke ("DisplayNum");
		for (int i = 0; i < UFOFactory.getInstance ().usingUFO.Count; i++) {
			DestroyObject(UFOFactory.getInstance ().usingUFO [i]);
		}
		for (int i = 0; i < UFOFactory.getInstance ().usingUFO.Count; i++) {
			UFOFactory.getInstance ().usingUFO.RemoveAt (i);
		}
		for (int j = 0; j < ExplosionList.Count; j++) {
			DestroyObject (ExplosionList [j]);
		}
		for (int j = 0; j < ExplosionList.Count; j++) {
			ExplosionList.RemoveAt (j);
		}
		Director.getInstance ().game_state = GameState.DISPLAY_SCORE;
		this.DisplayScore ();
	}
	public void DisplayScore (){
		Director.getInstance ().game_state = GameState.DISPLAY_SCORE;
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
		InvokeRepeating ("CreateUFO", 3f, timeEachUFO);
		display_num = 4;
		InvokeRepeating ("DisplayNum", 0f, 1f);
	}
		
	public void SetNumSpeed(){
		if (Director.getInstance ().round_state == RoundState.EASY) {
			NumOfUFO = 12;
			SpeedOfUFO = 8;
			ScoreOfUFO = 2;
			timeEachUFO = 1.5f;
		}else if (Director.getInstance ().round_state == RoundState.EASY) {
			NumOfUFO = 15;
			SpeedOfUFO = 12;
			ScoreOfUFO = 3;
			timeEachUFO = 1f;
		}
		else {
			NumOfUFO = 20;
			SpeedOfUFO = 20;
			ScoreOfUFO = 2;
			timeEachUFO = 1f;
		}
	}

	public void CreateUFO(){
		UFOFactory.getInstance ().getNewUFO ();
	}

	public void Update(){
		gamestate = Director.getInstance ().game_state;
		if (UsedUFONum >= NumOfUFO) {
			CancelInvoke("CreateUFO");
			this.GameOver ();
		}
		if (display_num < 1) {
			IfDisplayNum = false;
			CancelInvoke ("DisplayNum");
		}
	}

	public void DisplayNum(){
		display_num --;
		IfDisplayNum = true;
	}
}
