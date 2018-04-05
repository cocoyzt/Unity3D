/* 这个文件是用来管理游戏动作的，负责管理船向左移，向右移和人物移动的管理
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {

	public FirstSceneControl sceneController;
	public CCMoveToAction moveToLeft, moveToRight;
	public Dictionary<int, CCOn_OffAction> on_off = new Dictionary<int, CCOn_OffAction>();

	protected new void Start()
	{
		float speed = 5f;
		sceneController = (FirstSceneControl)Director.getInstance().currentSceneControl;
		sceneController.actionManager = this;

		//注册船向左移和向右移的动作和每个人物对应的上下船的动作
		moveToLeft = CCMoveToAction.GetSSAction(sceneController.Boat_Left, speed);
		moveToRight = CCMoveToAction.GetSSAction(sceneController.Boat_Right, speed);
		foreach (KeyValuePair<int, GameObject> obj in sceneController.On_Shore_r)
		{
			on_off[obj.Key] = CCOn_OffAction.GetSSAction();
		}

		//启动所有注册的动作
		this.RunAction(sceneController.boat, moveToLeft, this);
		this.RunAction(sceneController.boat, moveToRight, this);
		foreach (KeyValuePair<int, GameObject> obj in sceneController.On_Shore_r)
		{
			this.RunAction(obj.Value, on_off[obj.Key], this);
		}

	}

	public void SSActionEvent(SSAction source,
		SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0,
		string strParam = null,
		Object objectParam = null)
	{

	}

}