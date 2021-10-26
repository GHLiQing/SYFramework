using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	public class LevelExample : MonoBehaviourSimplify
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/6.LevelManager 测试",false,6)]
		private static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			new GameObject("LevelManager").AddComponent<LevelExample>();
		}

#endif
		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
			LevelManager.Init(new List<string>()
			{
				"StartScene",
				"LevelManager",
				
			});
			
			LevelManager.LoadCurrentLevel();
			Delay(5f, () => {
				Debug.Log("延迟5s");
				LevelManager.LoadNext(()=> {
					Debug.Log("levelManager scence");
					Destroy(gameObject);
				});

			});
			
		}



		protected override void OnBeforOnDestroy()
		{
			
		}
	}

}
