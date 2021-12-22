using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Reskit
{
	/// <summary>
	/// �첽���ز���
	/// </summary>
	public class ResMgrASyncExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021 /Moudle/12.ResMgrASyncExample  �첽���ز���  [New]",false,12)]
		public static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject(nameof(ResMgrASyncExample)).AddComponent<ResMgrASyncExample>();
		}

#endif
		ResLoader resLoader = new ResLoader();
		private void Awake()
		{
			resLoader.LoadAsync<GameObject>("resources://LoadCube", obj => {

				Instantiate(obj);
			});
		}

		private void OnDestroy()
		{
			resLoader.ReleaseAll();
			resLoader = null;
			Destroy(gameObject);
		}
	}

}
