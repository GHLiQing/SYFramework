using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 日期：2021.12.7
/// 目的：资源加载代码 重构
/// </summary>
namespace Reskit
{
	/// <summary>
	///  负责记录目标脚本已经加载的资源。
	/// </summary>
	public class ResLoader
	{
		
		/// <summary>
		/// 异步加载
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetName"></param>
		/// <param name="onLoaded"></param>
		public void LoadAsync<T>(string assetName,Action<T> onLoaded) where T :UnityEngine. Object
		{
			var res = GetOrCreatRes(assetName);
			if (res!=null)
			{
				onLoaded.Invoke(res.Asset as T);
				return;
			}

			res = CreatRes(assetName);

			Add2Record(res);

			//异步加载
			res.LoadAsyc(loadedRes=> {

				onLoaded.Invoke(loadedRes.Asset as T);
			});


		}


		/// <summary>
		/// 同步加载
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public T LoadSync<T>(string assetName) where T : UnityEngine. Object
		{

			//1 先从当前的mResRecord查找
			var res = GetOrCreatRes(assetName);

			if (res!=null)
			{
				return res.Asset as T;
			}
			//3 直接创建对象
			res = CreatRes(assetName);

			res.LoadSync();

			return res.Asset as T;
		}

		public void UnLoaderAsset()
		{
			mResRecord.ForEach(res => {

				res.Release();
			});
			mResRecord.Clear();
			mResRecord = null;
		}

		#region 提取
		private List<Res> mResRecord = new List<Res>();

		private Res GetOrCreatRes(string assetName)
		{
			var res = GetResFromRecord(assetName);
			if (res!=null)
			{
				return res;
			}

			res = GetResFromResMgr(assetName);
			if (res != null)
			{

				Add2Record(res);
				return res;
			}

			return res;
		}

		private Res GetResFromRecord(string assetName)
		{
			return mResRecord.Find(res => res.Name == assetName);
		}

		private Res GetResFromResMgr(string assetName)
		{
			return ResMgr.Instance.SharedLoadedRes.Find(record => record.Name == assetName);
		}
		 
		/// <summary>
		/// 添加到 record 池中
		/// </summary>
		/// <param name="res"></param>
		public void Add2Record(Res res)
		{
			mResRecord.Add(res);
			res.Retain();
		}

		/// <summary>
		/// 创建res 并且加入到全局资源池
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public Res CreatRes(string  assetName)
		{
			var res = new Res(assetName);
			ResMgr.Instance.SharedLoadedRes.Add(res);

			Add2Record(res);
			return res;

		}
		#endregion
	}

}
