using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QFramework.LQ
{
	/// <summary>
	/// 设置对象池接口 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IPool <T>
	{
		//分配
		 T Allocate();
		//回收
		bool Recycle(T obj);
	}
	/// <summary>
	/// 抽象类 用于扩展使用
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Pool<T> : IPool<T>
	{
		// 使用栈进行存取 连续地址存取 通过栈进行存取和回收
		protected Stack<T> mCacheObj = new Stack<T>();
		//通过工厂创建对象 
		protected IObjectFactory<T> mFactory;

		protected int MaxCount = 5;
		public int CurCount
		{
			get
			{
				return mCacheObj.Count;
			}
		}

		public virtual T Allocate()
		{
			return mCacheObj.Count == 0 
				? mFactory.Allocate() 
				: mCacheObj.Pop();//如果栈中没有 从工厂创建一个 如果栈中有 直接取出一个
		}
		/// <summary>
		/// 抽象方法 用于给子类扩展 回收机制
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public  abstract bool Recycle(T obj);
		
	}


	public class SimpleObjectPool<T> : Pool<T>
	{
		//回调
		readonly System.Action<T> mResetMethod;

		/// <summary>
		/// 通过这个对象池 返回一个传入的T 类型 
		/// </summary>
		/// <param name="factoryMethon"></param>
		/// <param name="resthethod"></param>
		/// <param name="initCount"></param>
		public SimpleObjectPool(System.Func<T> factoryMethon,System.Action<T> resthethod=null,int initCount = 0)
		{
			mFactory = new CustomObjectFactory<T>(factoryMethon);//通过CustomObjectFactory工厂创建对象
			mResetMethod = resthethod;
			for (int i = 0; i < initCount; i++)//初始化放入 initcount数量的对象
			{
				mCacheObj.Push(mFactory.Allocate());
			}
		}
		

		/// <summary>
		/// 回收
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Recycle(T obj)
		{
			if (mResetMethod!=null)
			{
				mResetMethod(obj);
			}
			mCacheObj.Push(obj);//回收对象
			return true;
		}
	}
}

