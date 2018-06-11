using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler{

    //for debug
    public float catz;

    //
    private Vector3 toLf;
    private Vector3 toRg;

    public bool faceLf;
    public bool walkto = false;
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

        ani.SetTrigger("Idle");
        faceLf = true ;
        LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.grey;
        RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.grey;

        toLf = new Vector3(0, 0, 1);
        toRg = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update () {

        //for debug
        catz = cat.transform.position.z;

        if (walkto/* && ani.GetCurrentAnimatorStateInfo(0).IsName("Walk")*/)
        {
            //if(cat.transform.position.z < 0.02f) cat.transform.position += new Vector3(0, 0, 0.0001f);
            if (catz <= 0.02f && catz >= -0.02f){
                if(faceLf) cat.transform.Translate(toLf * Time.deltaTime * 0.01f);
                else cat.transform.Translate(toLf * Time.deltaTime * 0.01f);
            }
            else
            {
                walkto = false;
                ani.ResetTrigger("Walk");
                ani.SetTrigger("Idle");
            }
        }
        
	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Lf":
                Debug.Log("Lfpressed");
                //change color of button
                if (LfBtnCube.GetComponent<MeshRenderer>().material.color == Color.grey)
                {
                    LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
                else LfBtnCube.GetComponent<MeshRenderer>().material.color = Color.grey;

                //change direction
                if (!faceLf) cat.transform.eulerAngles = new Vector3(0, 0, 0);
                faceLf = true;

                if(cat.transform.position.z > 0.02f)
                {
                    cat.transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, 0.018f);
                    catz = 0.018f;
                }
                if (cat.transform.position.z < -0.02f)
                {
                    cat.transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, -0.018f);
                    catz = -0.018f;
                }

                break;
            case "Rg":
                Debug.Log("Rgpressed");
                Debug.Log("walkto:" + walkto.ToString() + "catz: " + catz.ToString() + " " + cat.transform.position.z.ToString());
                //change color of button
                if (RgBtnCube.GetComponent<MeshRenderer>().material.color == Color.grey)
                {
                    RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
                else RgBtnCube.GetComponent<MeshRenderer>().material.color = Color.grey;

                //change direction
                if (faceLf) cat.transform.eulerAngles = new Vector3(0, -180, 0);
                faceLf = false;

                if (cat.transform.position.z > 0.02f)
                {
                    cat.transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, 0.018f);
                    catz = 0.018f;
                }
                if (cat.transform.position.z < -0.02f)
                {
                    cat.transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, -0.018f);
                    catz = -0.018f;
                }

                break;
        }

        ani.ResetTrigger("Idle");
        ani.SetTrigger("Walk");
        walkto = true;
        Debug.Log("walkto:" + walkto.ToString() + "catz: " + catz.ToString() + " " + cat.transform.position.z.ToString());
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("released");
        //ani.SetTrigger("Idle");
    }
}
