using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ
{
	/// <summary>
	/// 使用工厂模式
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IObjectFactory <T>
	{
		//存取
		T Allocate();
	}

	/// <summary>
	/// 扩展接口 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CustomObjectFactory<T> : IObjectFactory<T>
	{
		
		public CustomObjectFactory(System.Func<T> factoryMethod)
		{
			this.mFactoryMethod = factoryMethod;
		}
		//具有返回值的简单类型方法
		protected System.Func<T> mFactoryMethod;

		/// <summary>
		/// 返回T 类型的对象 进行创建存取
		/// </summary>
		/// <returns></returns>
		public T Allocate()
		{
			return mFactoryMethod();
		}
	}
}
