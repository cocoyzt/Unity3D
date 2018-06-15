using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    public GUISkin mySkin;

    void Start()
    {
        GUI.skin = mySkin;
    }

    private void OnGUI()
    {
        if (!Director.GetInstance().playing)
        {
            GUI.Label(new Rect(400, 100, 800, 450), "GameOver");
        }
    }
}
