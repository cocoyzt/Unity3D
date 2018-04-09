using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneControl, IUserAction {

	public CCActionManager actionManager { set; get;}
	public enum BoatState {MOVING, STOPLEFT, STOPRIGHT}
	public GameObject Shore_l;
	public GameObject Shore_r;
	public GameObject Boat;
	public int[] On_Boat = new int[2];
    public int[] On_Shore_l = new int[6];
    public int[] On_Shore_r = new int[6];
	public GameObject[] dp = new GameObject[6];

	public Vector3 Boat_Left = new Vector3 (-10f, -2.25f, 0);
	public Vector3 Boat_Right = new Vector3 (10f, -2.25f, 0);

	public GameState game_state;
	public int boat_capicity = 2;
	public BoatState boat_state = BoatState.STOPLEFT;

	void Awake(){
		Director director = Director.getInstance ();
		director.currentSceneControl = this;
		director.currentSceneControl.GenGameObjects ();
	}

	public void GenGameObjects(){
		for (int i = 0; i < 6; i++) {
			On_Shore_l [i] = i;
			On_Shore_r [i] = 6;
		}
		for (int i = 0; i < 2; i++)
			On_Boat [i] = 6;

		Shore_l = GameObject.CreatePrimitive (PrimitiveType.Cube);
		Shore_l.name = "Shore_l";
		Shore_l.transform.position = new Vector3 (-20f, 0, 0);
		Shore_l.transform.localScale = new Vector3(12f, 4.5f, 0);

		Shore_r = GameObject.CreatePrimitive (PrimitiveType.Cube);
		Shore_r.name = "Shore_r";
		Shore_r.transform.position = new Vector3 (20f, 0, 0);
		Shore_r.transform.localScale = new Vector3(12f, 4.5f, 0);

		Boat = GameObject.CreatePrimitive (PrimitiveType.Cube);
		Boat.name = "Boat";
		Boat.transform.position = Boat_Left;
		Boat.transform.localScale = new Vector3(8f, 0.5f, 4);

		GameObject Priest;
		float Priest_position_x = -25f;
		for (int i = 0; i < 3; i++) {
			Priest = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			Priest.transform.localScale = new Vector3 (1, 1, 1);
			Priest.transform.position = new Vector3 (Priest_position_x, 3f, 0);
			Priest_position_x += 2;
			Priest.AddComponent<On_Off> ();
			Priest.name = i.ToString();
			dp [i] = Priest;
		}

		GameObject Devil;
		float Devil_position_x = -19f;
		for(int i = 3;i < 6;i ++){
			Devil = GameObject.CreatePrimitive (PrimitiveType.Cube);
			Devil.transform.localScale = new Vector3 (1, 1, 1);
			Devil.transform.position = new Vector3 (Devil_position_x, 3f, 0);
			Devil_position_x += 2;
			Devil.AddComponent<On_Off> ();
			Devil.name = i.ToString();
			dp [i] = Devil;
		}
			
	}

	public void Update(){
		game_state = check ();

		if (game_state == GameState.NOT_ENDED) {
			if (Boat.transform.position.x < 10 && Boat.transform.position.x > -10)
				boat_state = BoatState.MOVING;
			else if (Boat.transform.position.x >= 10)
				boat_state = BoatState.STOPRIGHT;
			else
				boat_state = BoatState.STOPLEFT;

			for(int i = 0;i < 6;i ++){
				if (On_Shore_r [i] != 6) {
					dp [On_Shore_r [i]].transform.position = new Vector3 (25 - 2 * i, 3, 0);
				}
				if (On_Shore_l [i] != 6) {
					dp [On_Shore_l [i]].transform.position = new Vector3 (-25 + 2 * i, 3, 0);
				}
			}


			if (On_Boat [0] != 6) {
				dp [On_Boat [0]].transform.position = new Vector3 (Boat.transform.position.x - 2, 0.5f, 0);
			}
			if (On_Boat [1] != 6) {
				dp [On_Boat [1]].transform.position = new Vector3 (Boat.transform.position.x + 2, 0.5f, 0);
			}
		}
	}

	public void MoveBoat(){
		if (On_Boat [0] != 6 || On_Boat [1] != 6) {
			if (boat_state == BoatState.STOPLEFT) {
				actionManager.moveToRight.enable = true;
				if (On_Boat [0] != 6) {
					dp [On_Boat [0]].transform.position = new Vector3 (Boat.transform.position.x - 2, 0.5f, 0);
				}
				if (On_Boat [1] != 6) {
					dp [On_Boat [1]].transform.position = new Vector3 (Boat.transform.position.x + 2, 0.5f, 0);
				}
			}
			else if(boat_state == BoatState.STOPRIGHT){
				actionManager.moveToLeft.enable = true;
				if (On_Boat [0] != 6) {
					dp [On_Boat [0]].transform.position = new Vector3 (Boat.transform.position.x - 2, 0.5f, 0);
				}
				if (On_Boat [1] != 6) {
					dp [On_Boat [1]].transform.position = new Vector3 (Boat.transform.position.x + 2, 0.5f, 0);
				}
			}
		}
	}

	public void GameOver(){
		GUI.Label (new Rect (465, 50, 800, 450), "GameOver!");
	}

	public GameState check(){
		int dr_num = 0, dl_num = 0, db_num = 0;
		int pr_num = 0, pl_num = 0, pb_num = 0;
		for (int i = 0; i < 6; i++) {
			if (On_Shore_l [i] >= 0 && On_Shore_l [i] <= 2)
				pl_num++;
			else if (On_Shore_l [i] >= 3 && On_Shore_l [i] <= 5)
				dl_num++;
			if (On_Shore_r [i] >= 0 && On_Shore_r [i] <= 2)
				pr_num++;
			else if (On_Shore_r [i] >= 3 && On_Shore_r [i] <= 5)
				dr_num++;
		}
		if (On_Boat [0] >= 0 && On_Boat [0] <= 2)
			pb_num++;
		else if (On_Boat [0] >= 3 && On_Boat [0] <= 5)
			db_num++;

		if (On_Boat [1] >= 0 && On_Boat [1] <= 2)
			pb_num++;
		else if (On_Boat [1] >= 3 && On_Boat [1] <= 5)
			db_num++;

		if (dr_num + pr_num == 6)
			return GameState.WIN;

		if (boat_state == BoatState.STOPLEFT) {
			if (dr_num > pr_num && pr_num > 0)
				return GameState.FAILED;
			if (pl_num + pb_num > 0 && pl_num + pb_num < dl_num + db_num)
				return GameState.FAILED;
		} 
		else if (boat_state == BoatState.STOPRIGHT) {
			if (dl_num > pl_num && pl_num > 0)
				return GameState.FAILED;
			if (pr_num + pb_num > 0 && pr_num + pb_num < dr_num + db_num)
				return GameState.FAILED;
		}

		return GameState.NOT_ENDED;
	}

	public GameState getGameState(){
		return game_state;
	}
}
