using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.single
{
	public class SingleExample : SingletonNomal<SingleExample>
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/7.Sington 测试", false, 7)]
		private static void MenuOnClick()
		{
			var single = SingleExample.GetSinleton;
			
		}
#endif
		/// <summary>
		/// 继承 singleNomal 
		/// 不许有一个私有的构造函数
		/// </summary>
		private SingleExample()
		{
			Debug.Log("SingleExample");
		}
	}

}
