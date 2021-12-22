using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// res ����
	/// </summary>
	public class ResFactory
	{
		/// <summary>
		/// ����res ���Ҽ��뵽ȫ����Դ��
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public static Res CreatRes(string assetName, string assetBundleName = null)
		{
			Res res = null;

			//·��
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
