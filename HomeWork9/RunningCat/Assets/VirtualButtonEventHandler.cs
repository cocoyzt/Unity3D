using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler{


    public enum CatState {LEFT, MIDDLE, RIGHT}
    //for debug
    public float catz;

    //
    private Vector3 toLf;
    private Vector3 toRg;

    public CatState cat_state = CatState.MIDDLE;
    public GameObject cat;
    public GameObject LfBtnCube;
    public GameObject RgBtnCube;
    public Animator ani;
    public VirtualButtonBehaviour[] vbs;

    // Use this for initialization
    void Start () {
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0;i < vbs.Length;i ++)
        {
            vbs[i].RegisterEventHandler(this);
        }
       
        ani.SetTrigger("Walk");
        //color of buttons
        LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.black;
        RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.black;

        toLf = new Vector3(-1, 0, 0);
        toRg = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update () {

        if (Director.GetInstance().playing)
        {
            //for debug
            catz = cat.transform.position.z;

            //move cat 
            if (cat_state == CatState.LEFT && cat.transform.position.z < 0.3f)
            {
                cat.transform.Translate(toLf * Time.deltaTime * 1f);
            }
            else if (cat_state == CatState.RIGHT && cat.transform.position.z > -0.3f)
            {
                cat.transform.Translate(toRg * Time.deltaTime * 1f);
            }
            else
            {
                if (cat.transform.position.z > 0)
                {
                    cat.transform.Translate(toRg * Time.deltaTime * 1f);
                }
                else if (cat.transform.position.z < 0)
                {
                    cat.transform.Translate(toLf * Time.deltaTime * 1f);
                }
            }
        }
        else
        {
            ani.ResetTrigger("Walk");
            ani.SetTrigger("Idle");
        }
	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Lf":
                Debug.Log("Lfpressed");

                //change color of button
                LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.yellow;

                //change cat state
                if (cat_state == CatState.MIDDLE) cat_state = CatState.LEFT;
                else if (cat_state == CatState.RIGHT) cat_state = CatState.MIDDLE;
                else cat_state = CatState.LEFT;

                break;
            case "Rg":
                Debug.Log("Rgpressed");

                //change color of button
                RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.yellow;

                //change cat state
                if (cat_state == CatState.MIDDLE) cat_state = CatState.RIGHT;
                else if (cat_state == CatState.LEFT) cat_state = CatState.MIDDLE;
                else cat_state = CatState.RIGHT;

                break;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("released");
        //ani.SetTrigger("Idle");
        switch (vb.VirtualButtonName)
        {
            case "Lf":
                //change color of button
                LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.black;

                break;
            case "Rg":
                //change color of button
                RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.black ;
              
                break;
        }
    }
}
