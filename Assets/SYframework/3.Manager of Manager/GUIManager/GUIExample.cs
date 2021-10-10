using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace QFramework.LQ
{
	public class GUIExample : MonoBehaviourSimplify
	{

#if UNITY_EDITOR
		[MenuItem("FrameworkDesign2021/Moudle/1.测试GUI模块",false,1)]
		private static void MuneClick()
		{
			UnityEditor.EditorApplication.isPlaying =true;
			var example = new GameObject("GUIExample").AddComponent<GUIExample>();
			example.GUILayer = UILayer.Common;
		}
#endif

		public UILayer GUILayer=UILayer.Common;

	
		private void Start()
		{

			GUIManager.SetResolution(1920, 1080, 0.618f);
			var loadpanel = GUIManager.LoadPanel("LoadPanel",GUILayer);
			Delay(3f, () => {
				Debug.Log("延迟了3 s"+ loadpanel.name);
				GUIManager.UnLoadPanel("LoadPanel");
			});
		}

		protected override void OnBeforOnDestroy()
		{
			
		}
	}

}
