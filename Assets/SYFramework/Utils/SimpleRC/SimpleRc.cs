using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	interface IRefCounter
	{
		 int ReCount { get; }

		void Retain(object refOwner = null);

		void Release(object refOwner = null);
	}


	public class SimpleRc : IRefCounter
	{
		public int ReCount
		{
			get;
			private set;
		}

		public SimpleRc()
		{
			ReCount = 0;
		}

		/// <summary>
		/// 减引用 释放一次
		/// </summary>
		/// <param name="refOwner"></param>
		public void Release(object refOwner = null)
		{
			--ReCount;
			if (ReCount==0)
			{
				OnZeroRef();
			}
		}

		/// <summary>
		/// 加引用 引用添加一次
		/// </summary>
		/// <param name="refOwner"></param>
		public void Retain(object refOwner = null)
		{
			++ReCount;
		}
		
		/// <summary>
		/// 释放完成之后进行调用
		/// </summary>
		protected virtual void OnZeroRef()
		{

		}
	}


}
