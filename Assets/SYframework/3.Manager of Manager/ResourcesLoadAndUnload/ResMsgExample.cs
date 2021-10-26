using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ.single
{
	public class ResMsgExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/11.ResMsgExample", false,11)]
		private static void  MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			new GameObject("ResMsgExample").AddComponent<ResMsgExample>();
		}
#endif
		ResLoaderAsset mResLoaderAsset = new ResLoaderAsset();

		Player p1;
		private void Awake()
		{
			var res = new ResLoaderAsset();
			var clip= res.LoadSync<AudioClip>("resources://bg");
			AudioManager.Instance.PlayMusic(clip, true);
			//参数=> {  对参数进行的操作 }
			mResLoaderAsset.LoadAsync<GameObject>("resources://LoadCube", LoadCube => {
				Instantiate(LoadCube);
				//Debug.Log("loadCube: "+LoadCube.name);
			});

		

		}
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				mResLoaderAsset.LoadAsync<GameObject>("LoadCube", LoadCube => {
					Instantiate(LoadCube);
				});
			}
			//if (Input.GetKeyDown(KeyCode.Alpha1))
			//{
			//	string asc= p1.GetString("adb", adb => {

			//		Debug.Log("测试："+ adb);
			//	});
			//	Debug.Log("返回值测试：" + asc);
			//}
			
		}
		private void OnDestroy()
		{
			mResLoaderAsset.ReleaseAll();
		}



	}



}
