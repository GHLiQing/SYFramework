using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	public class PoolExample 
	{

		public class Fish
		{

		}
#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/5.poolManager 测试", false, 5)]
		private static void MenuClick()
		{
			var fishPool = new SimpleObjectPool<Fish>(() => new Fish(), (obj)=> { Debug.Log("移除之前的回调"); }, 100);
			Debug.Log("数量："+fishPool.CurCount); //100
			var fishONE = fishPool.Allocate(); //取一个
			Debug.Log("数量：" + fishPool.CurCount); //99

			fishPool.Recycle(fishONE);//回收一个
			Debug.Log("数量：" + fishPool.CurCount); //100
			for (int i = 0; i < 10; i++)
			{
				fishPool.Allocate(); 
			}
			Debug.Log("数量：" + fishPool.CurCount);//取10个 90
		}

#endif
	}
}
