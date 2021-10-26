using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Res 负责加载、卸载的操作。
//ResLoader 负责记录目标脚本已经加载的资源。
//ResMgr 负责维护全局的资源缓存池。
namespace SYFramework.LQ.single
{
	/// <summary>
	/// 加载的状态
	/// 通过加载的状态进行判断当前资源是否已经被加载了
	/// </summary>
	public enum ResState
	{
		Waiting, //等待加载
		Loading,//正在加载
		Loaded,//已经加载
	}
	/// <summary>
	/// 引用计数器 
	/// </summary>
	public abstract class Res:SimpleRC
	{
		private ResState mstate;

		//加载状态
		public ResState State { get {
				return mstate;
			}
			protected set {

				mstate = value;
				if (mstate == ResState.Loaded)
				{
					if (mLoadedEvent!=null)
					{
						mLoadedEvent.Invoke(this);
					}
				}
			}
		}

		protected event System.Action<Res> mLoadedEvent;

		public void RegisterLoadEvent(System.Action<Res> onLoaded)
		{
			mLoadedEvent += onLoaded;
		}
		public void UnRegisterLoadEvent(System.Action<Res> onLoaded)
		{
			mLoadedEvent -= onLoaded;
		}

		public string Name { get; protected set; }

		public Object Asset { get; protected set; }

		public abstract bool LoadSync();

		public abstract void LoadAsync();//System.Action<Res> onLoaded

		protected abstract void OnRelesasRes();

		protected override void OnZeroRef()
		{
			base.OnZeroRef();
			OnRelesasRes();
		}
	}
}

