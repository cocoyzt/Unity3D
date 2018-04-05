/* 这个文件所写接口是负责动作管理器和其管理的动作之间的通信
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType:int { Started, Competeted }

public interface ISSActionCallback {
	void SSActionEvent(SSAction source,
		SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0,
		string strParam = null,
		Object objectParam = null);

}