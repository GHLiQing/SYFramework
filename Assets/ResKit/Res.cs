using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reskit
{

	/// <summary>
	/// ������غ�ж�ز���
	/// </summary>
	public class Res:SimpleRC
	{

		public Res(string  path)
		{
			mPath = path;
			Name = path;
		}

		public Object Asset { get; private set; }

		private string mPath;

		public string Name{ get; private set; }

		
	
		protected override void OnZeroRef()
		{
			base.OnZeroRef();
			if (Asset is GameObject)
			{
				Resources.UnloadUnusedAssets();
			}
			else
			{
				Resources.UnloadAsset(Asset);
			}

			ResMgr.Instance.SharedLoadedRes.Remove(this);

			Asset = null;
		}


		/// <summary>
		/// ͬ������
		/// </summary>
		/// <returns></returns>
		public bool LoadSync()
		{
			return Asset = Resources.Load(mPath);
		}

		/// <summary>
		/// �첽����
		/// </summary>
		/// <param name="onLoaded"></param>
		public void LoadAsyc(System.Action<Res> onLoaded)
		{
			ResourceRequest resourceRequest = Resources.LoadAsync(mPath);
			resourceRequest.completed += o =>
			{
				Asset = resourceRequest.asset;
				onLoaded.Invoke(this);
			};

				
		}
	}


}
