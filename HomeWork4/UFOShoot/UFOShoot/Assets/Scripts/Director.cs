using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {IN_GAME, CHOOSE_ROUND, DISPLAY_SCORE, PAUSE}

public class Director : System.Object {

	public int score = 0;
	public RoundState round_state = RoundState.EASY;
	public GameState game_state = GameState.CHOOSE_ROUND;
	public ISceneController currentSceneControl{ get; set; }
	private static Director _instance;

	public static Director getInstance(){
		if (_instance == null)
			_instance = new Director ();
		return _instance;
	}
}
