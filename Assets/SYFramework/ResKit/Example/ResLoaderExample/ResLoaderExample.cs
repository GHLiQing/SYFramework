using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit.Example
{

	/// <summary>
	/// 服务对象
	/// </summary>
	public class ResLoaderExample : MonoBehaviour
	{
		/// <summary>
		/// 服务对象模式
		/// </summary>
		ResLoader resLoader = new ResLoader();

		private void Awake()
		{
			var cube= resLoader.LoadSync<GameObject>("LoadCube");
			Instantiate(cube);
		}

		private void OnDestroy()
		{
			resLoader.ReleaseAll();
		}
	}
}

