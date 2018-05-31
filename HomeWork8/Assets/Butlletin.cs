using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butlletin : MonoBehaviour {

    private Button btn;
    public bool Up;
    public Text text;
    public int textHeight;
    static List<Butlletin> buttonList;
    static int num;

	// Use this for initialization
	void Start () {
        buttonList = new List<Butlletin>();
        num = 0;
        object[] btnList = Resources.FindObjectsOfTypeAll(typeof(Butlletin));
        foreach(object item in btnList)
        {   
            num++;
            buttonList.Add((Butlletin)item);
        }

        Up = true;
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        textHeight = 360 - 40 * num;
	}
	
	// Update is called once per frame
	void Update () {

        textHeight = 360 - 40 * num;
        if (!Up)
        {
            if(text.rectTransform.sizeDelta.y < textHeight)
            {
                text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.rectTransform.sizeDelta.y + 4);
            }
        }
        else
        {
            if(text.rectTransform.sizeDelta.y > 0)
            {
                text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.rectTransform.sizeDelta.y - 4);
            }
        }
	}

    void OnClick()
    {
        Up = !Up;
        if (!Up)
        {
            foreach(Butlletin item in buttonList)
            {
                if (!item.Up && item != this)
                {
                    item.Up = !item.Up;
                }
            }
        }
    }
}
