using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer : NetworkBehaviour
{

    public enum CatState { LEFT, MIDDLE, RIGHT }

    public float catx;

    private Vector3 toLf;
    private Vector3 toRg;

    public CatState cat_state = CatState.MIDDLE;
    public GameObject cat;
    public Animator ani;
    // Use this for initialization
    void Start () {
        ani.SetTrigger("Walk");

        toLf = new Vector3(-1, 0, 0);
        toRg = new Vector3(1, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
            return;

        if (Director.GetInstance().playing)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (cat_state == CatState.MIDDLE) cat_state = CatState.RIGHT;
                else if (cat_state == CatState.LEFT) cat_state = CatState.MIDDLE;
                else cat_state = CatState.RIGHT;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (cat_state == CatState.MIDDLE) cat_state = CatState.LEFT;
                else if (cat_state == CatState.RIGHT) cat_state = CatState.MIDDLE;
                else cat_state = CatState.LEFT;
            }

            //for debug
            catx = cat.transform.position.x;
            //Debug.Log((cat.transform.position.x > -1.2f).ToString());

            //move cat 
            if (cat_state == CatState.LEFT && cat.transform.position.x > -1.2f)
            {
                cat.transform.Translate(toLf * Time.deltaTime * 2.0f);
            }
            else if (cat_state == CatState.RIGHT && cat.transform.position.x < 1.2f)
            {
                cat.transform.Translate(toRg * Time.deltaTime * 2.0f);
            }
            else if(cat_state == CatState.MIDDLE)
            {
                if (cat.transform.position.x > 0)
                {
                    cat.transform.Translate(toLf * Time.deltaTime * 2.0f);
                }
                else if (cat.transform.position.x < 0)
                {
                    cat.transform.Translate(toRg * Time.deltaTime * 2.0f);
                }
            }
        }
        else
        {
            cat.SetActive(false);
            ani.ResetTrigger("Walk");
            ani.SetTrigger("Idle");
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }
}
