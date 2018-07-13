using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCBoatMoveing : SSAction
{
    public ISceneController sceneController;

    public static CCBoatMoveing GetSSAction()
    {
        CCBoatMoveing action = ScriptableObject.CreateInstance<CCBoatMoveing>();
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
        if(FirstSceneController.movetheboat)
        {
            Debug.Log("Judge");
            if (FirstSceneController.On_Boat[0] != 6 || FirstSceneController.On_Boat[1] != 6)
            {
                if (FirstSceneController.boat_state == FirstSceneController.BoatState.STOPLEFT)
                {
                    FirstSceneController.Boat.transform.position = new Vector3(10f, -2.25f, 0);
                    if (FirstSceneController.On_Boat[0] != 6)
                    {
                        FirstSceneController.dp[FirstSceneController.On_Boat[0]].transform.position = new Vector3(FirstSceneController.Boat.transform.position.x - 2, 0.5f, 0);
                    }
                    if (FirstSceneController.On_Boat[1] != 6)
                    {
                        FirstSceneController.dp[FirstSceneController.On_Boat[1]].transform.position = new Vector3(FirstSceneController.Boat.transform.position.x + 2, 0.5f, 0);
                    }
                }
                else if (FirstSceneController.boat_state == FirstSceneController.BoatState.STOPRIGHT)
                {
                    FirstSceneController.Boat.transform.position = new Vector3(-10f, -2.25f, 0);
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
            FirstSceneController.movetheboat = false;
        }
    }
}
