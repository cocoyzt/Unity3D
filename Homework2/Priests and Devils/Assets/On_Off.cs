using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class On_Off : MonoBehaviour {

	private FirstSceneController firstSceneController;
	enum Pos { On_BOAT, ON_SHONE};

	// Use this for initialization
	void Start () {
		firstSceneController = (FirstSceneController)Director.getInstance().currentSceneControl;
	}

	private void OnMouseDown(){
		if (firstSceneController.game_state == GameState.NOT_ENDED) {
			if (firstSceneController.boat_state == FirstSceneController.BoatState.MOVING)
				return;
			int id = Convert.ToInt32 (this.name);
			if(firstSceneController.boat_state == FirstSceneController.BoatState.STOPRIGHT){
				for (int i = 0; i < 6; i++) {
					if (firstSceneController.On_Shore_r [i] == id && firstSceneController.boat_capicity != 0) {
						firstSceneController.On_Shore_r [i] = 6;
						firstSceneController.boat_capicity--;
						int Onto_Boat = 0;
						for (int j = 0; j < 2; j++) {
							if (firstSceneController.On_Boat [j] == 6) {
								Onto_Boat = j;
								break;
							}
						}
						firstSceneController.On_Boat [Onto_Boat] = id;
						float position_x = firstSceneController.Boat.transform.position.x - 2 + 4 * Onto_Boat;
						this.transform.position = new Vector3 (position_x, 0.5f, 0);
						return;
					}
				}

				for (int i = 0; i < 2; i++) {
					if (firstSceneController.On_Boat [i] == id) {
						firstSceneController.On_Boat [i] = 6;
						firstSceneController.boat_capicity ++;
						int Onto_Shore = 0;
						for (int j = 0; j < 6; j++) {
							if (firstSceneController.On_Shore_r [j] == 6) {
								Onto_Shore = j;
								break;
							}
						}
						firstSceneController.On_Shore_r [Onto_Shore] = id;
						int position_x = 25 - Onto_Shore * 2;
						this.transform.position = new Vector3 (position_x, 3, 0);
						return;
					}
				}
			}
			else if(firstSceneController.boat_state == FirstSceneController.BoatState.STOPLEFT){
				for (int i = 0; i < 6; i++) {
					if (firstSceneController.On_Shore_l [i] == id && firstSceneController.boat_capicity != 0) {
						firstSceneController.On_Shore_l [i] = 6;
						firstSceneController.boat_capicity--;
						int Onto_Boat = 0;
						for (int j = 0; j < 2; j++) {
							if (firstSceneController.On_Boat [j] == 6) {
								Onto_Boat = j;
								break;
							}
						}
						firstSceneController.On_Boat [Onto_Boat] = id;
						float position_x = firstSceneController.Boat.transform.position.x - 2 + 4 * Onto_Boat;
						this.transform.position = new Vector3 (position_x, 0.5f, 0);
						return;
					}
				}

				for (int i = 0; i < 2; i++) {
					if (firstSceneController.On_Boat [i] == id) {
						firstSceneController.On_Boat [i] = 6;
						firstSceneController.boat_capicity ++;
						int Onto_Shore = 0;
						for (int j = 0; j < 6; j++) {
							if (firstSceneController.On_Shore_l [j] == 6) {
								Onto_Shore = j;
								break;
							}
						}
						firstSceneController.On_Shore_l [Onto_Shore] = id;
						int position_x = -25 + Onto_Shore * 2;
						this.transform.position = new Vector3 (position_x, 3, 0);
						return;
					}
				}
			}
		}
	}
}
