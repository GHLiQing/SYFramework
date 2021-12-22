using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Reskit
{
	/// <summary>
	/// “Ï≤Ωº”‘ÿ≤‚ ‘
	/// </summary>
	public class ResMgrASyncExample : MonoBehaviour
	{
#if UNITY_EDITOR

		[MenuItem("FrameworkDesign2021 /Moudle/12.ResMgrASyncExample  “Ï≤Ωº”‘ÿ≤‚ ‘  [New]",false,12)]
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
