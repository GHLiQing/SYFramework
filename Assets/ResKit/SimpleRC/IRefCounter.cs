using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{
	/// <summary>
	/// ���׼�����
	/// </summary>
	public interface IRefCounter
	{
		int RefCount { get; }

		void Retain(object owen = null);
		void Release(object owen = null);
	}

	public class SimpleRC : IRefCounter
	{
		public SimpleRC()
		{
			RefCount = 0;
		}

		public int RefCount { get;  set; }

		public void Retain(object refOwner = null)
		{
			++RefCount;
		}

		public void Release(object refOwner = null)
		{
			--RefCount;

			if (RefCount == 0)
			{
				OnZeroRef();
			}
		}
		/// <summary>
		/// ����Ϊ0����
		/// </summary>
		protected virtual void OnZeroRef()
		{
		}
	}

}
