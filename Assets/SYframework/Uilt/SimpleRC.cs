using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	/// <summary>
	/// 引用计数器 工具
	/// </summary>
	interface IRefCounter
	{
		int RefCount { get; set; }
		void Retain(Object refowner = null);
		void Release(Object refowner = null);
	}

	public abstract class SimpleRC : IRefCounter
	{
		public int RefCount { get; set; }

		public void Release(Object refowner = null)
		{
			--RefCount;
			if (RefCount==0)
			{
				OnZeroRef();
			}
		}

		public void Retain(Object refowner = null)
		{
			++RefCount;

		}
		protected virtual void OnZeroRef() { }
		
	}


}
