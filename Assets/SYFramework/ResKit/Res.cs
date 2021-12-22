using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Reskit
{
	/// <summary>
	/// ��Ӽ���״̬
	/// </summary>
	public enum ResState
	{
		Waiting, //�ȴ�����
		Loading, //���ڼ���
		Loaded   //�Ѿ�����
	}

	/// <summary>
	/// �ṩ��Դ���ص�api
	/// </summary>
	public abstract class Res:SimpleRC
	{

		public string Name { get; protected set; }
		
		public UnityEngine.Object Asset { get; protected set; }

		public abstract bool LoadSync();

		public abstract void LoadAsync();

		public abstract void OnReleaseRes();

		protected override void OnZeroRef()
		{
			OnReleaseRes();
		}

		private ResState mState;
		public ResState State {

			get
			{
				return mState;
			}
			set
			{
				mState = value;
				if (mState==ResState.Loaded)
				{
					if (OnLoadEvent!=null)
					{
						OnLoadEvent.Invoke(this);
					}
				}
			}
		}

		protected event System.Action<Res> OnLoadEvent;

		public void RegisterLoadedEvent(Action<Res> Loaded)
		{
			OnLoadEvent += Loaded;
		}

		public void UnRegisterLoadedEvent(Action<Res> Loaded)
		{
			OnLoadEvent -= Loaded;
		}


	}


}
