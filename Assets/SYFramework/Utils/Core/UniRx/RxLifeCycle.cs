using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{
	public class RxLifeCycle : MonoBehaviour
	{
		private void Awake()
		{
			Observable.EveryUpdate().
				Where(_=>Input.GetMouseButtonDown(0)) //相当于if 判断
				.First() //只执行一次  Subscribe：订阅的事件或者回调
				.Subscribe(_ => {
				Debug.Log("鼠标只能点击一次");

			}).AddTo(this); 

			
		}
	}

}
