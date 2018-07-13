using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCGetOnTheBoat : SSAction
{
    public ISceneController sceneController;
 
    public static CCGetOnTheBoat GetSSAction()
    {
        CCGetOnTheBoat action = ScriptableObject.CreateInstance<CCGetOnTheBoat>();
        return action;
    }
    // Use this for initialization
    public override void Start()
    {
        sceneController = (ISceneController)Director.getInstance().currentSceneControl;
    }

    // Update is called once per frame
    public override void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (FirstSceneController.On_Shore_r[i] != 6)
            {
                FirstSceneController.dp[FirstSceneController.On_Shore_r[i]].transform.position = new Vector3(25 - 2 * i, 3, 0);
            }
            if (FirstSceneController.On_Shore_l[i] != 6)
            {
                FirstSceneController.dp[FirstSceneController.On_Shore_l[i]].transform.position = new Vector3(-25 + 2 * i, 3, 0);
            }
        }


        if (FirstSceneController.On_Boat[0] != 6)
        {
            FirstSceneController.dp[FirstSceneController.On_Boat[0]].transform.position = new Vector3(FirstSceneController.Boat.transform.position.x - 2, 0.5f, 0);
        }
        if (FirstSceneController.On_Boat[1] != 6)
        {
            FirstSceneController.dp[FirstSceneController.On_Boat[1]].transform.position = new Vector3(FirstSceneController.Boat.transform.position.x + 2, 0.5f, 0);
        }
    }
}