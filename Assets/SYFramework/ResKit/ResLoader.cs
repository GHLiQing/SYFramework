using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// ���ڣ�2021.12.7
/// Ŀ�ģ���Դ���ش��� �ع�
/// </summary>
namespace Reskit
{
	/// <summary>
	///  �����¼Ŀ��ű��Ѿ����ص���Դ��
	/// </summary>
	public class ResLoader
	{


		#region public ����ӿ�


		public T LoadSync<T>(string assetBundle, string assetName) where T : UnityEngine.Object
		{
			return DoLoadSync<T>(assetName, assetBundle);
		}

		public T LoadSync<T>(string assetName) where T : UnityEngine.Object
		{
			return DoLoadSync<T>(assetName);
		}

		public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : UnityEngine.Object
		{
			DoLoadAsync(assetName, null, onLoaded);
		}

		public void LoadAsync<T>(string assetBundleName, string assetName, Action<T> onLoaded) where T : UnityEngine.Object
		{
			DoLoadAsync(assetName, assetBundleName, onLoaded);
		}
		#endregion

		#region private


		private T DoLoadSync<T>(string assetName, string assetBundle = null) where T : UnityEngine.Object
		{
			var res = GetOrCreateRes(assetName, assetBundle);

			if (res.State == ResState.Waiting)
			{
				res.LoadSync();
			}
			else if (res.State == ResState.Loading)
			{
				throw new Exception(string.Format("�벻Ҫ���첽������Դ {0} ʱ������ {0} ��ͬ������", res.Name));
			}

			if (res.State == ResState.Loaded)
			{
				return res.Asset as T;
			}

			throw new Exception(string.Format("��Դ {0} ����ʧ��", res.Name));
		}

		private void DoLoadAsync<T>(string assetName, string assetBundleName, Action<T> onLoaded) where T :UnityEngine. Object
		{
			var res = GetOrCreateRes(assetName, assetBundleName);

			Action<Res> onResLoaded = null;

			onResLoaded = loadedRes =>
			{
				onLoaded(loadedRes.Asset as T);

				res.UnRegisterLoadedEvent(onResLoaded);
			};

			if (res.State == ResState.Waiting)
			{
				res.RegisterLoadedEvent(onResLoaded);

				res.LoadAsync();
			}
			else if (res.State == ResState.Loading)
			{
				res.RegisterLoadedEvent(onResLoaded);
			}
			else if (res.State == ResState.Loaded)
			{
				onLoaded(res.Asset as T);
			}
		}

		/// <summary>
		/// �ͷ���Դ
		/// </summary>
		public void ReleaseAll()
		{
			mResRecord.ForEach(res => {

				res.Release();
			});
			mResRecord.Clear();
			mResRecord = null;
		}

		
		private List<Res> mResRecord = new List<Res>();

		private Res GetOrCreateRes(string assetName,string assetBundle)
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
			res = CreatRes(assetName,assetBundle);
			return res;
		}

		private Res GetResFromRecord(string assetName)
		{
			return mResRecord.Find(res => res.Name == assetName);
		}

		private Res GetResFromResMgr(string assetName)
		{
			return ResMgr.Instance.SharedLoadedReses.Find(record => record.Name == assetName);
		}
		 
		/// <summary>
		/// ��ӵ� record ����
		/// </summary>
		/// <param name="res"></param>
		private void Add2Record(Res res)
		{
			mResRecord.Add(res);
			res.Retain();
		}

		/// <summary>
		/// ����res ���Ҽ��뵽ȫ����Դ��
		/// </summary>
		/// <param name="assetName"></param>
		/// <returns></returns>
		private Res CreatRes(string  assetName,string assetBundleName=null)
		{
			Res res = null;
			res = ResFactory.CreatRes(assetName, assetBundleName);

			ResMgr.Instance.SharedLoadedReses.Add(res);
			Add2Record(res);

			return res;

		}
		#endregion
	}

}
