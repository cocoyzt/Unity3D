using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManeger {

    private static TextManeger _instance;

    public int num;

	public static TextManeger GetInstance()
    {
        if(_instance == null)
        {
            _instance = new TextManeger();
        }
        return _instance;
    }
}
