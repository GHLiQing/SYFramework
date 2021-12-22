using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// res 工厂
	/// </summary>
	public class ResFactory
	{
		/// <summary>
		/// 创建res 并且加入到全局资源池
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public static Res CreatRes(string assetName, string assetBundleName = null)
		{
			Res res = null;

			//路由
			if (assetBundleName != null)
			{
				res = new AssetRes(assetName, assetBundleName);
			}
			else if (assetName.StartsWith("resources://"))
			{
				res = new ResourcesRes(assetName);
			}
			else
			{
				res = new AssetBundleRes(assetName);
			}

			return res;

		}
	}

}
