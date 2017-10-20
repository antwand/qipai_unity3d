using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using DG.Tweening;


namespace ant{


    /**
     * Mask
     * 
     * 全局遮罩
    * 
    *  
    * 
    * @author  jack   jackdevelop@sina.com
    * @date  2015-10-5 上午10:11
    * @version 1.0
    */
    public class Mask : MonoBehaviour {

        /*** tooltips 的prefable ***/
        public GameObject prefable;




        //TOOLTIPS的panel层 
        private GameObject _PANEL_TOOLTIPS;
        //实例化后的prefable
        private GameObject _prefable = null;




        /*** 单例模式 ***/
        public static Mask instance;
        void Awake()
        {
            instance = this;
            this._PANEL_TOOLTIPS = GameManager.getLayerBySceneLayerName(GameConstants.TIP_LAYER);
            //this._item = toolTipPrefable.transform.Find("item").gameObject;
        }










        /**
	     * 创建某一个item
	     * */
        public GameObject createItem(Transform parent, float alpha)
        {
            if (parent== null)
            {
                parent = this._PANEL_TOOLTIPS.transform;
            }

            if (alpha == null)
            {
                alpha = 0.5f;
            }


            GameObject itemPref = Instantiate(prefable) as GameObject;
            itemPref.SetActive(true);
            itemPref.transform.parent = parent;
            itemPref.transform.localScale = Vector3.one;
            itemPref.transform.localPosition = Vector3.zero;

            //设置透明度
            CanvasRenderer CanvasRenderer = itemPref.transform.GetComponent<CanvasRenderer>();
            CanvasRenderer.SetAlpha(alpha);

            //全屏
            UITool.setFullScreen(itemPref);

            return itemPref;
        }




        /**
         * 显示mask
         * @param parent 
         * @param alpha
         * */
        public static GameObject show(Transform parent=null, float alpha=0.5f)
        {
           return Mask.instance.createItem(parent,  alpha);
        }

    }


}