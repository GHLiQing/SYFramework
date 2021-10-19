using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
namespace SYFramework
{
	public class UniRxExample : MonoBehaviour
	{
		private void Awake()
		{

			List<int> number = new List<int> { 1, 52, 61, 20, 15, 60 };

			number.Where(nu => nu > 20)
				.ToList()
				.ForEach(nu => { Debug.Log(nu); });

			Observable.EveryUpdate()
				.Where(_ => Input.GetMouseButtonDown(0))
				.Subscribe(_ => {

					Debug.Log("�����");
				});
		}


		private void Test()
		{
			Debug.Log("��ʼʱ�䣺" + Time.realtimeSinceStartup);
			Observable.Timer(TimeSpan.FromSeconds(2))
				.Subscribe(_ => {

					Debug.Log("��ʱ2��" + Time.realtimeSinceStartup);

				}).AddTo(this);
		}
	}

}
