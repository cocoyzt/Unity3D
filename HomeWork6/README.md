#Unity3d-Patrol


## 视频链接
http://www.iqiyi.com/w_19rxtklcqd.html


##游戏设计要求
 - 创建一个地图和若干巡逻兵(使用动画)；
 - 每个巡逻兵走一个3~5个边的凸多边型，位置数据是相对地址。即每次确定下一个目标位置，用自己当前位置为原点计算；
 - 巡逻兵碰撞到障碍物，则会自动选下一个点为目标；
 - 巡逻兵在设定范围内感知到玩家，会自动追击玩家；
 - 失去玩家目标后，继续巡逻；
 - 计分：玩家每次甩掉一个巡逻兵计一分，与巡逻兵碰撞游戏结束；


## UML图
![此处输入图片的描述][1]


 - 这次作业的动作方面比较简单，就没有用动作管理器，直接写了挂在GameObject上
 - 观察者模式体现在分数的增加上，即FirstController观察GameEventManager


## 关键代码


###GameEventManager.cs
使用了观察者模式，将脚本挂在Trigger上，如果Hero与通道发生了碰撞，则发布消息，通知FirstController加分
```C#
public class GameEventManager : MonoBehaviour {  
	public delegate void AddScore();//委托  
	public static event AddScore addScore;//事件  
	// Use this for initialization  


	void OnTriggerEnter(Collider collider)  
	{  
		if (collider.gameObject.name == "Hero") {  
			Debug.Log ("hit by hero");
			add ();
		}
	}  


	void add()  
	{  
		if(addScore != null)  
		{  
			addScore();
		}  
	}  
}  
```
##PatrolAction.cs
 - 在Update中判断Hero是否在自己所巡逻的区间，如果是调用抓捕函数，不是调用巡逻函数
 - 抓捕函数参考了师兄的博客，用了MoveTowards()函数，简直不要太方便！
 - 巡逻函数随机产生一个在自己负责的区域内的坐标，然后用MoveTowards()函数走向那个坐标，如果临近了该坐标则重新随机产生别的坐标
```C#
public class PatrolAction : MonoBehaviour {


	public int index;
	public int dir = 0;
	private float BirthX = 0f;
	private float BirthZ = 0f;
	private double nextFire = 0;
	private FirstController fircon;
	private float max_x;
	private float min_x;
	private float max_z;
	private float min_z;
	private Vector3 disv3;




	// Use this for initialization
	void Start () {
		fircon = (FirstController)Director.getInstance ().currentSceneController;
		index = int.Parse (this.transform.name);
		BirthX = (float)(20 - (index % 3) * 20);
		BirthZ = (float)(20 - (index / 3) * 20);
		max_x = BirthX + 10;
		min_x = BirthX - 10;
		max_z = BirthZ + 10;
		min_z = BirthZ - 10;
		disv3 = new Vector3 (Random.Range(min_x + 2, max_x - 2), 0.6f, Random.Range(min_z + 2, max_z - 2));
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (fircon.gamestate != GameState.END) {
			if (Time.time > nextFire) {
				float x = this.transform.position.x;
				float z = this.transform.position.z;
				//judge if hero is in patrol's block
				if (index == fircon.hero_index) {
					Catch ();
				} else {
					Patrol (x, z);
				}
				nextFire = Time.time + 0.5;
			}
		}
	}


	public void Catch (){
		transform.position = Vector3.MoveTowards (this.transform.position, fircon.Hero.transform.position, 1f);
	}


	public void Patrol(float x, float z){
		if ((this.transform.position.x < disv3.x + 1) && (this.transform.position.x > disv3.x - 1)&&
			(this.transform.position.z < disv3.z + 1) && (this.transform.position.z > disv3.z - 1)) {
			disv3 = new Vector3 (Random.Range(min_x + 2, max_x - 2), 0.6f, Random.Range(min_z + 2, max_z - 2));
		} else {
			transform.position = Vector3.MoveTowards (this.transform.position, disv3, 1f);
		}
	}
		
	void OnCollisionEnter(Collision collider)  
	{  
		if (collider.gameObject.name == "Hero") {
			Debug.Log ("!!!");
			fircon.gamestate = GameState.END;
		}
	}  
}
```
 - 其他的也没有什么啦，什么FirstController、Director等等，都和之前的差不多。
 
 ##GitHub链接
 https://github.com/huangyt39/Unity3D/tree/master/HomeWork6/patrolman