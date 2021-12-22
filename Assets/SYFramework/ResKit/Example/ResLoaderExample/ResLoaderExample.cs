using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit.Example
{

	/// <summary>
	/// �������
	/// </summary>
	public class ResLoaderExample : MonoBehaviour
	{
		/// <summary>
		/// �������ģʽ
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

