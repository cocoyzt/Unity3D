## 视频链接
http://v.youku.com/v_show/id_XMzU0MDc3Njg3Mg==.html?spm=a2hzp.8253869.0.0  

## 游戏模式
包括easy,normal,hard三个模式，三个模式的UFO数量，速度和出现频率上有区别，每个UFO的分数也不尽相同。  

## UFO工厂类
第一次做工厂类感觉实现的不是很好，没有完全发挥其优势，还是借助了很多次实例化和Destory，Explosion也没有实现工厂类，以后再慢慢领悟和实践把。  

## UI
自己做了Button,Label,Box的背景图，用了GUISkin让UI变得好看一些，可惜画风和UFO还是有些维和；  
UFO一开始想用Assets Store上的资源，可是似乎没法挂上OnMouseDown()函数，或许要加碰撞器？有点复杂就放弃了，用了普通的圆柱，有红绿蓝三种颜色，颜色用随机数生成；  
explosion用了Assets Store上的资源，一开始总是重复爆炸，后来摸索摸索发现了作者预设了一个public成员变量loop来控制其是否循环爆炸，很方便。  

## MVC
对什么数据应该放在哪个文件中还是有些混乱，没有很好的分离数据和控制器，UI控制器和场景控制器之间的连接也做的不好，不过项目比较小，后果不是毁灭性的，以后慢慢改进。  

## 未解决的问题
在不同的状态跳转有时会产生失灵的问题，明明是同一个game_state，可是在不同的情况下有时候按钮会失灵有时候正常，找不到解决的方法..  