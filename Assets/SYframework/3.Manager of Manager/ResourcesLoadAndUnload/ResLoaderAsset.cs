using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework.LQ.single;
using System;
/// <summary>
/// 33 异步加载资源
/// </summary>
namespace QFramework.LQ.single
{
	/// <summary>
	/// 资源加载 服务类 
	/// 使用方法：使用的时候声明 ResLoaderAsset 这个变量 调用加载和卸载方法即可
	/// </summary>
	public class ResLoaderAsset
	{

		#region API  对外接口

		public T LoadSync<T>(string assetBundle,string assetName) where T : UnityEngine. Object
		{
			return DoLoadSync<T>(assetName, assetBundle);
		}


		public T LoadSync<T>(string assetName) where T : UnityEngine.Object
		{
			return DoLoadSync<T>(assetName);

		}

		public void LoadAsync<T>(string assetName,Action<T> onLoaded) where T:UnityEngine.Object
		{
			DoLoadAsync<T>(assetName, null, onLoaded);

		}

		public void LoadAsync<T>(string assetName,string assetBundle,Action<T> onLoaded) where T:UnityEngine.Object
		{
			DoLoadAsync<T>(assetName, assetBundle, onLoaded);
		}
		#endregion

		#region private API

		
		/// <summary>
		/// 解决加载资源重复的问题
		/// 方法解读：
		/// 首先需要两次查询 一个局部记录查询 还有一个全局查询 
		/// 在没有查询得到的时候进行资源加载加载添加集合中
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetName"></param>
		/// <returns></returns>
		private T DoLoadSync<T>(string assetName,string assetBundle=null) where T : UnityEngine.Object
		{
			//  1.先从当前对象中的  mResRecord 查找资源对象
			var resload = GetOrCreatFromRecord(assetName, assetBundle);

			if (resload.State==ResState.Waiting)
			{
				resload.LoadSync();
			}
			else if (resload.State==ResState.Loading)
			{
				throw new Exception(string.Format("请不要异步{0}加载资源时，进行{0}同步加载资源", resload.Name));

			}

			if (resload.State==ResState.Loaded)
			{
				
				return resload.Asset as T ;
			}

			//resload = CreateRes(assetName);

			//resload.LoadSync();

			//return resload.Asset as T;
			throw new Exception(string.Format("资源{0}加载失败", resload.Name));
		}
		/// <summary>
		/// 异步加载资源
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetname"></param>
		/// <param name="onLoadRes"> 资源在加载完成之后的时候回调</param>
		/// <returns></returns>
		private void DoLoadAsync<T>(string assetname, string assetBundleName,System.Action<T> onLoadRes) where T :UnityEngine.Object
		{
			var res = GetOrCreatFromRecord(assetname, assetBundleName);
			Action<Res> onResLoaded = null;
			//注册个回调
			onResLoaded = loadedRes =>
			{

				onLoadRes(loadedRes.Asset as T);
				res.UnRegisterLoadEvent(onResLoaded);

			};

			if (res.State==ResState.Waiting)
			{
				res.RegisterLoadEvent(onResLoaded);

				res.LoadAsync();//loaddedRes => onLoadRes(loaddedRes.Asset as T)
			}
			else if (res.State==ResState.Loading)
			{
				//如何处理？
				res.RegisterLoadEvent(onResLoaded);

			}
			else if (res.State==ResState.Loaded)
			{
				onLoadRes(res.Asset as T);
			}

			#region 原来的设计
			//if (res!=null)
			//{
			//	//Debug.Log("回调 第一次在集合中提前资源");
			//	//把T 资源进行一些操作 比如实例化 调用这个委托
			//	onLoadRes(res.Asset as T);
			//	return ;
			//}

			//res = CreateRes(assetname);
			////异步资源加载
			////res 会把当前资源存入到asset中
			//res.LoadAsync(loadres => {

			//	//调用 得到当前加载出来的资源对象进行调用
			//	onLoadRes(res.Asset as T);
			//	//Debug.Log("第一次异步加载完成后调用 res name:"+res.Name+ "    loadres:"+ loadres.Name);

			//});
			#endregion

		}

		#endregion
		#region private

		//当前服务类res 集合 用于添加和访问
		private List<Res> mResRecord = new List<Res>();


		private Res GetOrCreatFromRecord(string assetname,string assetBundle)
		{
			var res = ResFromRecord(assetname);
			if (res!=null)
			{
				return res;
			}
			res = GetResFromResMgr(assetname);
			if (res!=null)
			{
				AddRes2Record(res);
				return res;
			}
			res = CreateRes(assetname, assetBundle);
			
			//res.LoadSync();

			return res;

		}
		/// <summary>
		/// 查找集合中是否含有
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		private Res ResFromRecord(string assetName)
		{
			return mResRecord.Find(res => res.Name == assetName);
			
		}
		/// <summary>
		/// 查找全局集合是否含有
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		private Res GetResFromResMgr(string assetName)
		{
			return ResMgr.Instance.SharedLoadedReses.Find(sharedAsset => sharedAsset.Name == assetName);
		}
		/// <summary>
		/// 添加到当前记录的集合中
		/// </summary>
		/// <param name="resFromResMgr"></param>
		private void AddRes2Record(Res resFromResMgr)
		{
			//引用调用计数
			resFromResMgr.Retain();

			mResRecord.Add(resFromResMgr);
		}
		/// <summary>
		/// 创建 res
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		private Res CreateRes(string assetName,string assetBundleName=null)
		{
			Res res = null;

			//路由机制（url 解析）
			if (assetBundleName!=null)
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
			ResMgr.Instance.SharedLoadedReses.Add(res);
			AddRes2Record(res);
			return res;
		}

		#endregion

		/// <summary>
		/// 卸载所有资源
		/// </summary>
		public void ReleaseAll()
		{
			mResRecord.ForEach(mresrecord=> {
				if (mresrecord.Asset is GameObject)
				{
					//Resources.UnloadUnusedAssets();
				}
				else
				{
					//Resources.UnloadAsset(mresrecord.Asset);
				}
			});
			//Debug.Log("count:" + mResRecord.Count);

			//释放资源
			mResRecord.Clear();
			mResRecord = null;
		}
	}
}

