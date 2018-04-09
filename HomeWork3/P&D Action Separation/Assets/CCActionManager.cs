using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {

	public FirstController sceneController;
	public CCMovetoAction moveToLeft, moveToRight;
	public Dictionary<int, CCOn_OffAction> on_off = new Dictionary<int, CCOn_OffAction> ();

	// Use this for initialization
	void Start () {
		float speed = 4f;
		sceneController = (FirstController)Director.getInstance ().currentSceneControl;
		sceneController.actionManager = this;

		moveToLeft = CCMovetoAction.GetSSAction (sceneController.Boat_Left, speed);
		moveToRight = CCMovetoAction.GetSSAction (sceneController.Boat_Right, speed);
		for (int i = 0; i < 6; i++) {
			on_off [i] = CCOn_OffAction.GetSSAction (i);
		}

		this.RunAction (sceneController.Boat, moveToLeft, this);
		this.RunAction (sceneController.Boat, moveToRight, this);
		for (int i = 0; i < 6; i++) {
			this.RunAction (sceneController.dp [i], on_off [i], this);
		}
	}

	public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0, string strParam = null, Object objectParam = null)
	{
	}

	public CCActionManager(){
	
	}
}
