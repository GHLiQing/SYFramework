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
		
		/// <summary>
		/// �첽����
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

			//�첽����
			res.LoadAsyc(loadedRes=> {

				onLoaded.Invoke(loadedRes.Asset as T);
			});


		}


		/// <summary>
		/// ͬ������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetName"></param>
		/// <returns></returns>
		public T LoadSync<T>(string assetName) where T : UnityEngine. Object
		{

			//1 �ȴӵ�ǰ��mResRecord����
			var res = GetOrCreatRes(assetName);

			if (res!=null)
			{
				return res.Asset as T;
			}
			//3 ֱ�Ӵ�������
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

		#region ��ȡ
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
		/// ��ӵ� record ����
		/// </summary>
		/// <param name="res"></param>
		public void Add2Record(Res res)
		{
			mResRecord.Add(res);
			res.Retain();
		}

		/// <summary>
		/// ����res ���Ҽ��뵽ȫ����Դ��
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
