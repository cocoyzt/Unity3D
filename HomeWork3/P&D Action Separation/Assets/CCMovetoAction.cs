using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMovetoAction : SSAction {

	public Vector3 target;
	public float speed;

	public static CCMovetoAction GetSSAction(Vector3 target, float speed)
	{
		CCMovetoAction action = ScriptableObject.CreateInstance<CCMovetoAction>();
		action.target = target;
		action.speed = speed;
		Debug.Log(speed.ToString());
		return action;
	}
	// Use this for initialization
	public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

		if (this.transform.position == target)
		{
			this.enable = false;
			this.callback.SSActionEvent(this);
		}
	}
}
