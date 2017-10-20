/**
 *
 * GameConstants 常量
 *
 * 游戏的相关静态数据
 *
 * @author antwand@sina.com
 * @type {{}}
 */


namespace ant
{


	public class GameConstants
	{
	        //指定父类的显示层
	        public  const string BACKGROUND_LAYER= "Panel_BG";//返回背景图
	        public  const string DEBUG_LAYER="debugLayer";//debug层

	        public  const string FLOORS_LAYER= "Panel_FLOOR";//地板层
	        public const string FLY_LAYER= "Panel_FLY";//建筑的上一飞行层
	        public  const string BATCH_LAYER= "Panel_BATCH";//中间建筑层

	        public const string TOUCH_LAYER="touchLayer";//触摸层
	        public const string UI_LAYER= "Panel_UI";//ui层
	        public const string LOADING_LAYER = "Panel_LOADING";//地图的loading层
	        public const string TIP_LAYER = "Panel_TIPS";//tips层




	    //层级
	    //public const string DEFAULT_OBJECT_ZORDER = 200;//默认物体的zorder
	    //public const string MAX_OBJECT_ZORDER = 20000; //最高物体的zorder












	        //基础事件
	       //public  const string EVENT_ENTERSCENE = "EVENT_ENTERSCENE"; //进入场景事件 enterScene



	}

}