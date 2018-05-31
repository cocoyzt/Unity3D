using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add : MonoBehaviour {

    private Button btn;
    public GameObject parent;
    public InputField title, detail;
    public GameObject newtit;
    public GameObject newdet;
    public GameObject buttom;

    // Use this for initialization
    void Start () {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        if(title.text != "" && detail.text != "")
        {
            //new title
            GameObject Title = Instantiate(newtit);
            Title.transform.parent = parent.transform;

            //new detail
            GameObject Detail = Instantiate(newdet);
            Detail.transform.parent = parent.transform;

            Title.GetComponent<Butlletin>().text = Detail.GetComponent<Text>();

            Title.GetComponent<Button>().GetComponentInChildren<Text>().text = title.text;
            Title.GetComponent<Butlletin>().text.text = detail.text;

            GameObject bottom = GameObject.Find("Buttom");
            Destroy(bottom);
            GameObject newBot = Instantiate(buttom);
            newBot.transform.parent = parent.transform;
            newBot.name = "Buttom";
        }
    }

}
