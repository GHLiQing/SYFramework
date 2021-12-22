using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace SYFramework
{

	/// <summary>
	/// IObservable 发布者
	/// IObserver 订阅者
	/// </summary>
	public class Model : IObservable<int>
	{

		protected readonly List<IObserver<int>> mObservers;
		public Model()
		{
			mObservers = new List<IObserver<int>>();
		}

		/// <summary>
		/// 更新数据 
		/// 一般为回到
		/// </summary>
		/// <param name="ioc"></param>
		public void UpdataLevel(int ioc)
		{
			foreach (var observer in mObservers)
			{
				if (ioc<0)
				{
					observer.OnError(new Exception("小于0值"));
				}
				else
				{
					observer.OnNext(ioc);
				}
			}
		}

		public void QuitGame()
		{
			foreach (var item in mObservers)
			{
				if (mObservers.Contains(item))
				{
					item.OnCompleted();
				}
			
			}
			mObservers.Clear();
		}

		/// <summary>
		/// 订阅
		/// </summary>
		/// <param name="observer"></param>
		/// <returns></returns>
		public IDisposable Subscribe(IObserver<int> observer)
		{
			if (!mObservers.Contains(observer))
				mObservers.Add(observer);
			return new UnSubscrible(mObservers, observer);
		}
	}


	/// <summary>
	/// 取消注册
	/// </summary>
	public class UnSubscrible : IDisposable
	{
		
		private List<IObserver<int>> mObservers;
		private IObserver<int> observer;

		

		public UnSubscrible(List<IObserver<int>> mObservers, IObserver<int> observer)
		{
			this.mObservers = mObservers;
			this.observer = observer;
		}

		public void Dispose()
		{
			if (observer != null && mObservers.Contains(observer))
				mObservers.Remove(observer);
		}
	}
}

