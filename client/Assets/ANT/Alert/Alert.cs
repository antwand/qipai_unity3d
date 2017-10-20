using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace ant
{
    /**
     
        //使用方法 
        Alert.show("Y用户名密码不做 ","ddd",ok,no);
        void ok()
        {
            print("ok");
        }
        void no()
        {
            print("no");
        }
        
     * */
    public class Alert : MonoBehaviour
    {
        /*** tooltips 的prefable ***/
        public GameObject prefable;



        GameObject _PANEL_TOOLTIPS =null;
        //某一个item
        private GameObject _alertPrefable = null;




        /*** 单例模式 ***/
        public static Alert instance;
        void Awake()
        {
            instance = this;
            this._PANEL_TOOLTIPS = GameManager.getLayerBySceneLayerName(GameConstants.TIP_LAYER);
            //this._item = toolTipPrefable.transform.Find("item").gameObject;
        }




        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }



        /**
        * 创建某一个item
        * */
        private Action _confirmfun;
        private Action _canclefun;
        public void createItem(string title, string tip, Action confirmfun, Action canclefun)
        {
            this._confirmfun = confirmfun;
            this._canclefun = canclefun;

            GameObject mask = null;
            if (_alertPrefable ==null)
            {
                if (this._PANEL_TOOLTIPS == null) {
                    this._PANEL_TOOLTIPS = GameManager.getLayerBySceneLayerName(GameConstants.TIP_LAYER);
                }

                _alertPrefable = Instantiate(prefable) as GameObject;
                _alertPrefable.transform.parent = _PANEL_TOOLTIPS.transform;
                _alertPrefable.transform.localScale = Vector3.one;
                _alertPrefable.transform.localPosition = Vector3.zero;


                mask = Mask.show(_alertPrefable.transform,0.5f);
                mask.transform.SetSiblingIndex(0);
                mask.name = "mask";
                //int count = parentTransform.childCount;
                //参数为物体在当前所在的子物体列表中的顺序
                //count-1指把child物体在当前子物体列表的顺序设置为最后一个，0为第一个


                Button btn_confirm = _alertPrefable.transform.Find("btn_confirm").transform.GetComponentInChildren<Button>();
                EventTriggerListener.Get(btn_confirm.gameObject).onClick = OnBTNClick;


                Button btn_cancle = _alertPrefable.transform.Find("btn_cancle").transform.GetComponentInChildren<Button>();
                EventTriggerListener.Get(btn_cancle.gameObject).onClick = OnBTNClick;
            }
            else
            {
                //设置透明度
                mask = _alertPrefable.transform.Find("mask").gameObject;
                CanvasRenderer CanvasRenderer = mask.transform.GetComponent<CanvasRenderer>();
                CanvasRenderer.SetAlpha(0.5f);
            }

           

            _alertPrefable.SetActive(true);
            Text Txt_titile = _alertPrefable.transform.Find("txt_title").transform.GetComponentInChildren<Text>();
            Txt_titile.text = title;
            Text Txt_tip = _alertPrefable.transform.Find("txt_tips").transform.GetComponentInChildren<Text>();
            Txt_tip.text = tip;

         
        }
        private void OnBTNClick(GameObject go)
        {
            this._alertPrefable.SetActive(false);
            //在这里监听按钮的点击事件
            if (go.name.Contains("btn_confirm"))
            {
                Debug.Log("btn_confirm");
                if (_confirmfun != null)
                {
                    _confirmfun();
                }
              
            }
            else
            {
                Debug.Log("btn_cancle");
                if (_canclefun != null)
                {
                    _canclefun();
                }
            }
        }
      





        /**
            * 显示
            */
        public static void show(string title, string tip, Action confirmfun, Action canclefun)
        {
            Alert.instance.createItem(title, tip,  confirmfun,  canclefun);
        }

    }

}