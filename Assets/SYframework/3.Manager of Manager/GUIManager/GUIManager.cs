using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.LQ
{
	public enum UILayer
	{
		Bg,
		Common,
		Top
	}

	/// <summary>
	/// 负责加载和卸载资源  gui
	/// </summary>
	public class GUIManager:MonoBehaviour
	{
		//一种单例模式
		private static GameObject mPrivateUIRoot;
		/// <summary>
		/// 通过一种属性的方式获取游戏物体
		/// </summary>
		public static GameObject GetUIRoot
		{
			get
			{
				if (mPrivateUIRoot==null)
				{
					var uiroot = Resources.Load<GameObject>("UIRoot");
					mPrivateUIRoot = GameObject.Instantiate(uiroot);
					mPrivateUIRoot.name = "UIRoot";
				}
				return mPrivateUIRoot;
			}
			
		}

		//用于卸载使用
		private static Dictionary<string, GameObject> mPanelDic = new Dictionary<string, GameObject>();
		/// <summary>
		/// 卸载面板
		/// </summary>
		/// <param name="panelName"></param>
		public static void UnLoadPanel(string panelName)
		{
			if (mPanelDic.ContainsKey(panelName))
			{
				Destroy(mPanelDic[panelName]);
			}
		}
		/// <summary>
		/// 设置屏幕适配
		/// </summary>
		/// <param name="weight"></param>
		/// <param name="hight"></param>
		/// <param name="math"></param>
		public static void SetResolution(float width,float hight,float math)
		{
			var uirootScaler = GetUIRoot.GetComponent<CanvasScaler>();
			uirootScaler.referenceResolution = new Vector2(width, hight);
			uirootScaler.matchWidthOrHeight = math;
		}

		/// <summary>
		/// 用于加载一些面板
		/// </summary>
		/// <param name="panelName">面板的名字</param>
		/// <param name="uILayer">面板层级</param>
		/// <returns></returns>
		public static GameObject LoadPanel(string panelName,UILayer uILayer)
		{
			var panelprefabs = Resources.Load<GameObject>(panelName);
			var go = GameObject.Instantiate<GameObject>(panelprefabs);
			go.name = panelName;
			
			mPanelDic.Add(panelName, go);
			switch (uILayer)
			{	
				case UILayer.Bg:
					go.transform.SetParent(GetUIRoot.transform.Find("Bg"));
					break;
				case UILayer.Common:
					go.transform.SetParent(GetUIRoot.transform.Find("Common"));
					break;
				case UILayer.Top:
					go.transform.SetParent(GetUIRoot.transform.Find("Top"));
					break;
				default:
					break;
			}
			go.transform.localScale = Vector3.one;
			var recrtran = go.transform as RectTransform;
			// 左下角锚框距离ui左下角的距离
			recrtran.offsetMin = Vector3.zero;
			// 右上角锚框距离ui右上角的距离
			recrtran.offsetMax = Vector3.zero;
			//表征的是元素Pivot到锚框中心点的距离
			recrtran.anchoredPosition = Vector3.zero;
			//设置锚点 相对于父物体的占比
			recrtran.anchorMax = Vector3.one;
			recrtran.anchorMin = Vector3.zero;

			return go;
		}
	}
}

