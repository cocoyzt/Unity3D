using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    //public GUISkin mySkin;
    public GameObject UI;

    void Start()
    {
        //GUI.skin = mySkin;
        UI.SetActive(false);
    }

    private void OnGUI()
    {
        if (!Director.GetInstance().playing)
        {
            //GUI.Label(new Rect(400, 100, 800, 450), "GameOver");
            UI.SetActive(true);
        }
    }
}
