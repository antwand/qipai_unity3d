using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ant
{

    /**
     * GameManager 
     * 
     * 游戏的核心管理 
     * 
     * */
    public class GameManager : MonoBehaviour {

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        // Use this for initialization
        void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}



		/****
	     *  获取当前的场景中Canvas 下的各种ui  
	     *  
	     * @param parentLayerName  
	     * 
	     * */
		public static GameObject getLayerBySceneLayerName(string parentLayerName)
		{
			GameObject canvas = GameObject.Find("Canvas");
			// var Canvas = cc.find("Canvas")
			GameObject currentLayer = canvas.transform.Find(parentLayerName).gameObject;

			/**
			if (parentLayerName == GameConstants.BACKGROUND_LAYER)//背景层
				currentLayer = this.bgLayer;
			else if (parentLayerName == GameConstants.FLOORS_LAYER)//地板层
				currentLayer = this.floorsLayer;
			else if (parentLayerName == GameConstants.FLY_LAYER) //飞行层
				currentLayer = this.flysLayer;
			//else if (parentLayerName == GameConstants.TOUCH_LAYER) //触摸层
			//    currentLayer = null;
			else if (parentLayerName == GameConstants.UI_LAYER) //ui层
				currentLayer = this.uiLayer;
			else if (parentLayerName == GameConstants.LOADING_LAYER) //地图的loading层
				currentLayer = this.loadingLayer;
			else if (parentLayerName == GameConstants.TIP_LAYER)//tips层
				currentLayer = this.tipLayer;
			else
				currentLayer = this.batch;
				**/
			return currentLayer;
		}




        // test 测试
        public void test()
        {
            print("diaji ==========");
            Alert.show("Y用户名密码不做 ","ddd",null,null);
            //ToolTips.show("测试tooltips ");
            //Mask.show();//测试mask
        }
       
	}


}