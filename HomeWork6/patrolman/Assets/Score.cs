﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int score = 0;
	void GetScore(){
		score++;
	}
		
	void Start(){
		GameEventManager.addScore += GetScore;
	}
}