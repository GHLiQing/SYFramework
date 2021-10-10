using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LQFramework
{

	public interface IReusable
	{
		/// <summary>
		/// 实例化
		/// </summary>
		void OnSpawned();

		/// <summary>
		/// 主动 回收
		/// </summary>
		void OnUpSpawned();
	}

}
