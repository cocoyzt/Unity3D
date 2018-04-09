using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class On_Off : MonoBehaviour {

	private FirstController firstSceneController;
	enum Pos { On_BOAT, ON_SHONE};

	// Use this for initialization
	void Start () {
		firstSceneController = (FirstController)Director.getInstance().currentSceneControl;
	}

	private void OnMouseDown(){
		if (firstSceneController.game_state == GameState.NOT_ENDED) {
			if (firstSceneController.boat_state == FirstController.BoatState.MOVING)
				return;
			int id = Convert.ToInt32 (this.name);
			firstSceneController.actionManager.on_off [id].enable = true;
		}
	}
}
