using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using DG.Tweening;

using ant;

namespace ant {




    /**
     * ToolTips  
     * 
     *  ToolTips.show("显示消息 ")
     * 
     * */
    public class ToolTips : MonoBehaviour {

        /*** tooltips 的prefable ***/
        public GameObject prefable;



        //消失时间  
        private const float TIME_ITEM_DESTROY = 0.5f;
        //TOOLTIPS的panel层 
        private GameObject _PANEL_TOOLTIPS;


        /*** 单例模式 ***/
        public static ToolTips instance;
        void Awake()
        {
            instance = this;
            this._PANEL_TOOLTIPS = GameManager.getLayerBySceneLayerName(GameConstants.TIP_LAYER);
            //this._item = toolTipPrefable.transform.Find("item").gameObject;
        }


        /**
	     * 创建某一个item
	     * */
        public void createItem(string text)
        {
        
            GameObject itemPref = Instantiate(prefable) as GameObject;
            itemPref.SetActive(true);
            itemPref.transform.parent = this._PANEL_TOOLTIPS.transform;
            itemPref.transform.localScale = Vector3.one;
            itemPref.transform.localPosition = Vector3.zero;


            Text Txt_label = itemPref.GetComponentInChildren<Text>();
            Txt_label.text = text;


            /**
		    if (label.height > label.fontSize) {
			    label.alignment = NGUIText.Alignment.Left;
			    float scal = 1.0f*label.height / label.fontSize;
			    UISprite box = itemPref.transform.FindChild("box").GetComponent<UISprite>();
			    box.height =(int)(box.height*scal);
		    }
		    **/

            //itemPref.transform.d .DOMove(new Vector3(2,2,2), 2).SetEase(Ease.OutQuint).SetLoops(4).OnComplete(myFunction);
            //TweenAlpha.Begin (itemPref, 0.5f, 1);
            StartCoroutine(StartDestroyItem(itemPref, TIME_ITEM_DESTROY));
        }


        IEnumerator StartDestroyItem(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            if (obj != null)
            {
                obj.transform.DOLocalMoveY(Screen.height + 10, 4f, false);
                //TweenAlpha.Begin (obj, 0.5f, 0);
                yield return new WaitForSeconds(4f);
                if (obj != null) Destroy(obj);
            }
        }






        /**
	     *  显示文字  
	     * @param msg 
	     * */
        public static void show(string msg){
            ToolTips.instance.createItem(msg);
        }
    }



}