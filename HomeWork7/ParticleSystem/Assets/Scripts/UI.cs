using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public delegate void ClickAction(Object sender, string info);
    public static event ClickAction OnclickAction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 30), "Boom!"))
        {
            if (OnclickAction != null) OnclickAction(this, "click1!");
        }
    }
}
