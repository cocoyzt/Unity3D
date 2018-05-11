using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {INGAME, END, PAUSE}

public interface IUserAction {
	void Pause ();
	void End ();
	void Begin ();
	GameState getGamestate ();
	int getScore ();
}